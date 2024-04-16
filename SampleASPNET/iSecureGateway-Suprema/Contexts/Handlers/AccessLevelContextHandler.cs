using iSecureGateway_Suprema.Commons.Base;
using iSecureGateway_Suprema.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace iSecureGateway_Suprema.Contexts.Handlers
{
    public class AccessLevelContextHandler : IBaseRepository<AccessLevel>
    {
        private readonly IServiceProvider serviceProvider;

        public AccessLevelContextHandler(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<ICollection<AccessLevel>> FindAll()
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();
            return await context.AccessLevels.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<AccessLevel>> FindByConditionList(Expression<Func<AccessLevel, bool>> expression)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            return await context.AccessLevels.Where(expression).AsNoTracking().ToListAsync();
        }

        public async Task<AccessLevel?> FindByCondition(Expression<Func<AccessLevel, bool>> expression)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            return await context.AccessLevels.Where(expression).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task Insert(AccessLevel entity)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            try
            {
                context.AccessLevels.Add(entity);

                await context.SaveChangesAsync();
            }
            catch
            {
                context.Entry(entity).State = EntityState.Detached;
                throw;
            }
        }
        public async Task Update(AccessLevel entity)
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

        public async Task Delete(AccessLevel entity)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            try
            {
                context.AccessLevels.Remove(entity);

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

            return await context.AccessLevels.DefaultIfEmpty().MaxAsync(u => u == null ? 0 : u.Id);
        }
    }
}
