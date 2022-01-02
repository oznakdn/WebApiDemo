using System.Linq.Expressions;
using WebApiDemo.Business.Abstract;
using WebApiDemo.DataAccess.Abstract;
using WebApiDemo.Entities;

namespace WebApiDemo.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }



        public void Add(Product entity)
        {
            _productDal.Add(entity);

        }

        public void Delete(int id)
        {
            
            _productDal.Delete(id);
        }

        public Product Get(int id)
        {
            return _productDal.Get(x => x.ProductID == id);
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> Filter = null)
        {
            return _productDal.GetAll(Filter);
        }

        public void Update(Product entity,int id)
        {
            var product = _productDal.GetAll(x => x.ProductID == id).SingleOrDefault();

            product.ProductName = entity.ProductName != default ? entity.ProductName : product.ProductName;
            product.CategoryID = entity.CategoryID != default ? entity.CategoryID : product.CategoryID;
            product.UnitPrice = entity.UnitPrice != default ? entity.UnitPrice : product.UnitPrice;
            product.UnitsInStock = entity.UnitsInStock != default ? entity.UnitsInStock : product.UnitsInStock;

            _productDal.Update(product);

        }
    }
}
