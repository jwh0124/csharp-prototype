using FluentValidation;
using iSecureGateway_Suprema.Commons.Config.Auth;
using iSecureGateway_Suprema.Commons.Http.Request;
using iSecureGateway_Suprema.Contexts.Handlers;
using iSecureGateway_Suprema.DTO;
using iSecureGateway_Suprema.Interfaces;
using iSecureGateway_Suprema.Libs;
using iSecureGateway_Suprema.Services;
using iSecureGateway_Suprema.Validators;

namespace iSecureGateway_Suprema.Commons.Config
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddServiceDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<AccessEventContextHandler>();
            services.AddSingleton<AccessGroupContextHandler>();
            services.AddSingleton<AccessLevelContextHandler>();

            services.AddSingleton<MqttConnector>();
            services.AddSingleton<HttpAuthentication>();
            
            services.AddTransient<IAccessGroupService, AccessGroupService>();
            services.AddTransient<IAccessLevelService, AccessLevelService>();

            services.AddScoped<IValidator<AccessGroupDto>, AccessGroupValidator>();
            services.AddScoped<IValidator<RequestInfoDto>, CommonDtoValidator>();

            return services;
        }
    }
}
