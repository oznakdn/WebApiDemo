using System.Linq.Expressions;
using WebApiDemo.DataAccess.Abstract;
using WebApiDemo.Entities;

namespace WebApiDemo.DataAccess.Concrete
{
    public class EfProductDal:EfRepositoryBase<Product,NorthwindContext>,IProductDal
    {
      
        
    }
}
