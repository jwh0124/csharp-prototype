using iSecureGateway_Suprema.Commons.Base;
using iSecureGateway_Suprema.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace iSecureGateway_Suprema.Contexts.Handlers
{
    public class AccessGroupContextHandler : IBaseRepository<AccessGroup>
    {
        private readonly IServiceProvider serviceProvider;

        public AccessGroupContextHandler(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<ICollection<AccessGroup>> FindAll()
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();
            return await context.AccessGroups.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<AccessGroup>> FindByConditionList(Expression<Func<AccessGroup, bool>> expression)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            return await context.AccessGroups.Where(expression).AsNoTracking().ToListAsync();
        }

        public async Task<AccessGroup?> FindByCondition(Expression<Func<AccessGroup, bool>> expression)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            return await context.AccessGroups.Where(expression).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task Insert(AccessGroup entity)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            try
            {
                context.AccessGroups.Add(entity);

                await context.SaveChangesAsync();
            }
            catch
            {
                context.Entry(entity).State = EntityState.Detached;
                throw;
            }
        }
        public async Task Update(AccessGroup entity)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            try
            {
                context.Entry(entity).State = EntityState.Modified;

                await context.SaveChangesAsync();
            }
            catch
            {
                context.Entry(entity).State = EntityState.Detached;
                throw;
            }
        }

        public async Task Delete(AccessGroup entity)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            try
            {
                context.AccessGroups.Remove(entity);

                await context.SaveChangesAsync();
            }
            catch
            {
                context.Entry(entity).State = EntityState.Detached;
                throw;
            }
        }

        public async Task<uint> FindByMaxId()
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            return await context.AccessGroups.DefaultIfEmpty().MaxAsync(u => u == null ? 0 : u.Id);
        }
    }
}
