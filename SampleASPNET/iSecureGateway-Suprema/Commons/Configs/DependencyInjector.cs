using iSecureGateway_Suprema.Contexts.Handlers;
using iSecureGateway_Suprema.Interfaces;
using iSecureGateway_Suprema.Services;

namespace iSecureGateway_Suprema.Commons.Config
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddServiceDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<AccessGroupContextHandler>();
            services.AddSingleton<AccessLevelContextHandler>();
            services.AddSingleton<AccessScheduleContextHandler>();

            services.AddTransient<IAccessGroupService, AccessGroupService>();
            services.AddTransient<IAccessLevelService, AccessLevelService>();
            services.AddTransient<IAccessScheduleService, AccessScheduleService>();

            return services;
        }
    }
}
