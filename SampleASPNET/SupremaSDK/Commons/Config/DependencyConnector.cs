using Microsoft.Extensions.DependencyInjection;
using SupremaSDK.Managements;

namespace SupremaSDK.Commons.Config
{
    public static class DependencyConnector
    {
        public static IServiceCollection AddSDKDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<CardManagement>();
            services.AddSingleton<ConfigureManagement>();
            services.AddSingleton<DeviceManagement>();
            services.AddSingleton<LogManagement>();
            services.AddSingleton<UserManagement>();
            services.AddSingleton<AccessControlManagement>();
            services.AddSingleton<SlaveControlManagement>();
            services.AddSingleton<ZoneControlManagement>();
            services.AddSingleton<DoorControlManagement>();

            return services;
        }
    }
}
