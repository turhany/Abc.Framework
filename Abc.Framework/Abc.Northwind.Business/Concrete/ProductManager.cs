using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Abc.Core.Aspects.Postsharp.Caching;
using Abc.Core.Aspects.Postsharp.Logging;
using Abc.Core.Aspects.Postsharp.Transaction;
using Abc.Core.Aspects.Postsharp.Validation;
using Abc.Core.CrossCuttingConcerns.Caching.Microsoft;
using Abc.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Abc.Core.DataAccess;
using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Business.ValidationRules.FluentValidations;
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

        //TODO: PerformanceAspect method basında çalıştırılması
        //[PerformanceCounterAspect(5)]
        [CacheAspect(typeof(MemoryCacheManager))]
        [LogAspect(typeof(FileLogger))]
        public List<Product> GetAll()
        {
            Thread.Sleep(6000);

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

        //TODO: Validation kullanımı senaryo 3(aspect)
        [FluentValidationAspect(typeof(ProductValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect]
        [LogAspect(typeof(DatabaseLogger))]
        public void Add(Product product)
        {
            _productDal.Add(product);

            //Transaction örneklemesi için
            //_productDal.Add(new Product());

            //TODO: Validation kullanımı senaryo 2 (generic validator)
            //ValidationTool.FluentValidate(new ProductValidator(), product);
            //_productDal.Add(product);

            //TODO: Validation kullanımı senaryo 1 (direk validator)
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

        [TransactionScopeAspect]
        [CacheRemoveAspect]
        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        [CacheRemoveAspect]
        public void DeleteById(int productId)
        {
            _productDal.Delete(new Product() { ProductId = productId });
        }

        public List<Product> QueryableList()
        {
            var result = _productRepository.Table.Where(p => p.ProductName.Contains("a"));//context açıldı

            //iş kuralları kodları

            var result2 = result.Where(p => p.UnitPrice > 10);

            return result2.ToList();//tolist dediğimizde kapandı -> aynı transaction içinde oldu
        }
    }
}
