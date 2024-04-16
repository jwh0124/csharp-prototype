using FluentValidation.AspNetCore;
using iSecureGateway_Suprema;
using iSecureGateway_Suprema.Commons.Config;
using iSecureGateway_Suprema.Contexts;
using iSecureGateway_Suprema.Libs;
using iSecureGateway_Union.Commons.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MQTTnet.AspNetCore;
using MQTTnet.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SupremaContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("SupremaContext"),
                            options => options.EnableRetryOnFailure())
                            , ServiceLifetime.Transient);

builder.Services.AddSwaggerGen(x =>
{
    x.AddSecurityDefinition("X-Api-Key", new OpenApiSecurityScheme
    {
        Name = "X-Api-Key",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKeyScheme",
        In = ParameterLocation.Header,
        Description = "ApiKey must appear in header"
    });

    x.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "X-Api-Key"
                },
                In = ParameterLocation.Header
            },
            Array.Empty<string>()
        }
    });
});

// Add services to the container.
builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetSection("ApplicationSettings"));

builder.Services.AddAutoMapper(typeof(MapperProfiles));

builder.Services.AddServiceDependencyInjection();

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddHostedMqttServer(optionsBuilder =>
{
    optionsBuilder.WithDefaultEndpoint();
});
builder.Services.AddMqttConnectionHandler();
builder.Services.AddConnections();

var mqttEnabled = Convert.ToBoolean(builder.Configuration["ApplicationSettings:MQTT:Enabled"]?.ToString());

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5260);

    if (mqttEnabled)
    {
        serverOptions.ListenAnyIP(Convert.ToInt32(builder.Configuration["ApplicationSettings:MQTT:Port"]), l => l.UseMqtt());
    }
});

builder.Services.AddHostedService<Worker>();

builder.Host.UseWindowsService(option => option.ServiceName = "ISecureGateway-Suprema");

builder.Services.AddControllers().AddNewtonsoftJson();
// .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve)
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Services.GetService<ILoggerFactory>()
    .AddFile(builder.Configuration["LogFilePath"]?.ToString());

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


try
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();
    context.Database.Migrate();
}
catch (Exception e)
{
    app.Logger.LogCritical("Database connection error {e}", e.Message);
}

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

if (mqttEnabled)
{
    app.UseMqttServer(server =>
    {
        var mqttConnector = app.Services.GetService<MqttConnector>();
        server.ClientConnectedAsync += mqttConnector!.OnClientConnected;
        server.ClientDisconnectedAsync += mqttConnector!.OnClientDisConnected;

        app.Lifetime.ApplicationStopping.Register(() => server.StopAsync());
    });
}

app.UseMiddleware<HttpMiddleware>();
    
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();