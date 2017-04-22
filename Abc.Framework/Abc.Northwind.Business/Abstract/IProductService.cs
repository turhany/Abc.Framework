
using System.Collections.Generic;
using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetByCategory(int catergoryId);
        Product GetById(int productId);
        void Add(Product product);
        void Update(Product product);
        void DeleteById(int productId);
        List<Product> QueryableList();
    }
}
