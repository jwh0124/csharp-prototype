using iSecureGateway_Suprema.Commons.Base;
using iSecureGateway_Suprema.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace iSecureGateway_Suprema.Contexts.Handlers
{
    public class AccessScheduleContextHandler(IServiceProvider serviceProvider) : IBaseRepository<AccessSchedule>
    {
        private readonly IServiceProvider serviceProvider = serviceProvider;

        public async Task<ICollection<AccessSchedule>> FindAll()
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();
            return await context.AccessSchedules.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<AccessSchedule>> FindByConditionList(Expression<Func<AccessSchedule, bool>> expression)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            return await context.AccessSchedules.Where(expression).AsNoTracking().ToListAsync();
        }

        public async Task<AccessSchedule?> FindByCondition(Expression<Func<AccessSchedule, bool>> expression)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            return await context.AccessSchedules.Where(expression).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task Insert(AccessSchedule accessSchedule)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            try
            {
                context.AccessSchedules.Add(accessSchedule);

                await context.SaveChangesAsync();
            }
            catch
            {
                context.Entry(accessSchedule).State = EntityState.Detached;
                throw;
            }
        }
        public async Task Update(AccessSchedule accessSchedule)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            try
            {
                context.Entry(accessSchedule).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            catch
            {
                context.Entry(accessSchedule).State = EntityState.Detached;
                throw;
            }
        }

        public async Task Delete(AccessSchedule accessSchedule)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            try
            {
                context.AccessSchedules.Remove(accessSchedule);

                await context.SaveChangesAsync();
            }
            catch
            {
                context.Entry(accessSchedule).State = EntityState.Detached;
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
