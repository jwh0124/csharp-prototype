using iSecureGateway_Suprema.Commons.Base;
using iSecureGateway_Suprema.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace iSecureGateway_Suprema.Contexts.Handlers
{
    public class AuthorContextHandler(IServiceProvider serviceProvider) : IBaseRepository<Author>
    {
        private readonly IServiceProvider serviceProvider = serviceProvider;

        public async Task<ICollection<Author>> FindAll()
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();
            return await context.Authors.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<Author>> FindByConditionList(Expression<Func<Author, bool>> expression)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            return await context.Authors.Where(expression).AsNoTracking().ToListAsync();
        }

        public async Task<Author?> FindByCondition(Expression<Func<Author, bool>> expression)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            return await context.Authors.Where(expression).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task Insert(Author author)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            try
            {
                context.Authors.Add(author);

                await context.SaveChangesAsync();
            }
            catch
            {
                context.Entry(author).State = EntityState.Detached;
                throw;
            }
        }
        public async Task Update(Author author)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            try
            {
                context.Entry(author).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            catch
            {
                context.Entry(author).State = EntityState.Detached;
                throw;
            }
        }

        public async Task Delete(Author author)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            try
            {
                context.Authors.Remove(author);

                await context.SaveChangesAsync();
            }
            catch
            {
                context.Entry(author).State = EntityState.Detached;
                throw;
            }
        }

        public async Task<uint> FindByMaxId()
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            return await context.Authors.DefaultIfEmpty().MaxAsync(u => u == null ? 0 : u.Id);
        }
    }
}
