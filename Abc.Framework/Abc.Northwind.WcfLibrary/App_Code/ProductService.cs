using System.Collections.Generic;
using System.Linq;
using Abc.Core.Utilities.Common;
using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Business.DependencyResolvers.Ninject;
using Abc.Northwind.Entities.Concrete;

public class ProductService : IProductService
{
    private readonly IProductService _productService;

    //TODO:Soap'ta parametreli ctor yok
    public ProductService()
    {
        _productService = InstanceFactory.GetInstance<IProductService>(new BusinessModule());

        //TODO: automapper çalıştırılacak
        //Mapper.Initialize(cfg =>
        //{
        //    cfg.CreateMap<List<Product>, List<Product>>();
        //});
    }
    //ef üzerinden data alıp vermek için ef entity automapper ile dto atmak lazım
    //ef objesi serialize olmuyor datayı vermek için
    public List<Product> GetAll()
    {
        return _productService.GetAll().Select(p => new Product()
        {
            CategoryId = p.CategoryId,
            ProductId = p.ProductId,
            ProductName = p.ProductName,
            UnitPrice = p.UnitPrice,
            UnitsInStock = p.UnitsInStock
        }).ToList();

        //var result = _productService.GetAll();
        //return Mapper.Map<List<Product>, List<Product>>(result);
    }

    public List<Product> GetByCategory(int catergoryId)
    {
        throw new System.NotImplementedException();
    }

    public Product GetById(int productId)
    {
        throw new System.NotImplementedException();
    }

    public void Add(Product product)
    {
        throw new System.NotImplementedException();
    }

    public void Update(Product product)
    {
        throw new System.NotImplementedException();
    }

    public void DeleteById(int productId)
    {
        throw new System.NotImplementedException();
    }

    public List<Product> QueryableList()
    {
        throw new System.NotImplementedException();
    }

    public List<Product> Search(Product product)
    {
        return _productService.Search(product);
    }
}