using System.Collections.Generic;
using System.Linq;
using Abc.Core.Aspects.Postsharp;
using Abc.Core.Aspects.Postsharp.Caching;
using Abc.Core.Aspects.Postsharp.Validation;
using Abc.Core.CrossCuttingConcerns.Caching.Microsoft;
using Abc.Core.CrossCuttingConcerns.Validation.FluentValidation;
using Abc.Core.DataAccess;
using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Business.ValidationRules.FluentValidations;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.Entities.Concrete;
using FluentValidation;

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

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Product> GetByCategory(int catergoryId)
        {
            return _productDal.GetList(p => p.CategoryId == catergoryId);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        //level 3
        [FluentValidationAspect(typeof(ProductValidator))]
        public void Add(Product product)
        {
            _productDal.Add(product);

            //level 2
            //ValidationTool.FluentValidate(new ProductValidator(), product);
            //_productDal.Add(product);

            //level1
            //ProductValidator validator = new ProductValidator();
            //var result = validator.Validate(product);

            //if (result.IsValid)
            //{
            //    _productDal.Add(product);
            //}
            //else
            //{
            //    throw new ValidationException(result.Errors);
            //}
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
