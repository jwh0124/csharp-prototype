using iSecureGateway_Suprema.Models;
using Microsoft.EntityFrameworkCore;

namespace iSecureGateway_Suprema.Contexts.Handlers
{
    public class AccessEventContextHandler
    {
        private readonly IServiceProvider serviceProvider;

        public AccessEventContextHandler(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task Insert(AccessEvent eventAccess)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();
            try
            {
                context.AccessEvents.Add(eventAccess);

                await context.SaveChangesAsync();
            }
            catch
            {
                context.Entry(eventAccess).State = EntityState.Detached;
                throw;
            }
        }
    }
}
