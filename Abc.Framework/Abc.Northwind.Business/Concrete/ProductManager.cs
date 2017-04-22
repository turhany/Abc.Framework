using System.Collections.Generic;
using System.Linq;
using Abc.Core.DataAccess;
using Abc.Northwind.Business.Abstract;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IQueryableRepository<Product> _productRepository;

        public ProductManager(IProductDal productDal, IQueryableRepository<Product> productRepository)
        {
            _productDal = productDal;
            _productRepository = productRepository;
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Product> GetByCategory(int catergoryId)
        {
            return _productDal.GetList(p => p.CategoryId == catergoryId);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public void DeleteById(int productId)
        {
            _productDal.Delete(new Product() { ProductId = productId });
        }

        public List<Product> QueryableList()
        {
            var result = _productRepository.Table.Where(p => p.ProductName.Contains("a"));//context açıldı

            //başka kodlar

            var result2 = result.Where(p => p.UnitPrice > 10);

            return result2.ToList();//tolist dediğimizde kapandı -> aynı transaction içinde oldu
        }
    }
}
