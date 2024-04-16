using System.Linq.Expressions;

namespace iSecureGateway_Suprema.Commons.Base
{
    public interface IBaseRepository<T>
    {
        Task<ICollection<T>> FindAll();
        Task<ICollection<T>> FindByConditionList(Expression<Func<T, bool>> expression);
        Task<T?> FindByCondition(Expression<Func<T, bool>> expression);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
