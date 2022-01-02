using System.Linq.Expressions;
using WebApiDemo.Entities;

namespace WebApiDemo.Business.Abstract
{
    public interface IProductService
    {
        void Add(Product entity);
        void Update(Product entity,int id);
        void Delete(int id);
        Product Get(int id);
        List<Product> GetAll(Expression<Func<Product, bool>> Filter = null);
    }
}
