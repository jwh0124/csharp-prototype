using iSecureGateway_Suprema.Commons.Base;
using iSecureGateway_Suprema.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace iSecureGateway_Suprema.Contexts.Handlers
{
    public class PostContextHandler(IServiceProvider serviceProvider) : IBaseRepository<Post>
    {
        private readonly IServiceProvider serviceProvider = serviceProvider;

        public async Task<ICollection<Post>> FindAll()
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();
            return await context.Posts.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<Post>> FindByConditionList(Expression<Func<Post, bool>> expression)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            return await context.Posts.Where(expression).AsNoTracking().ToListAsync();
        }

        public async Task<Post?> FindByCondition(Expression<Func<Post, bool>> expression)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            return await context.Posts.Include(navigationPropertyPath: x => x.Authors).Where(expression).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task Insert(Post post)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            try
            {
                if(post.Authors !=null){
                    post.Authors.ToList().ForEach(x => context.Entry(x).State = EntityState.Unchanged);
                }

                context.Posts.AddRange(post);

                await context.SaveChangesAsync();
            }
            catch
            {
                context.Entry(post).State = EntityState.Detached;
                throw;
            }
        }
        public async Task Update(Post post)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            try
            {
                var entityList = await context.PostAuthors.Where(ag => ag.PostCode!.Equals(post.Code)).ToListAsync();
                context.PostAuthors.RemoveRange(entityList);

                await context.SaveChangesAsync();
                
                if(post.Authors !=null){
                    post.Authors.ToList().ForEach(x => context.Entry(x).State = EntityState.Unchanged);
                }

                context.Posts.Update(post);

                await context.SaveChangesAsync();
            }
            catch
            {
                context.Entry(post).State = EntityState.Detached;
                throw;
            }
        }

        public async Task Delete(Post post)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            try
            {
                context.Posts.Remove(post);

                await context.SaveChangesAsync();
            }
            catch
            {
                context.Entry(post).State = EntityState.Detached;
                throw;
            }
        }

        public async Task<uint> FindByMaxId()
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupremaContext>();

            return await context.Posts.DefaultIfEmpty().MaxAsync(u => u == null ? 0 : u.Id);
        }
    }
}
