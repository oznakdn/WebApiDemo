using System.Linq.Expressions;
using WebApiDemo.Entities;

namespace WebApiDemo.DataAccess.Abstract
{
    public interface IEfRepository<T> where T:class,IEntity,new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        T Get(Expression<Func<T, bool>> Filter);
        List<T> GetAll(Expression<Func<T, bool>> Filter = null);
    }
}
