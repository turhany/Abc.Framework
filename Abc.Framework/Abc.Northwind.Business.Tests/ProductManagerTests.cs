using Abc.Core.DataAccess;
using Abc.Northwind.Business.Concrete;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.Entities.Concrete;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Abc.Northwind.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))] //method geçebilmesi için vermesi gereken exception
        [TestMethod]
        public void ProductValidationCheck()
        {
            Mock<IProductDal> productDalMock = new Mock<IProductDal>();
            Mock<IQueryableRepository<Product>> repositoryMock = new Mock<IQueryableRepository<Product>>();

            ProductManager productManager = new ProductManager(productDalMock.Object, repositoryMock.Object);
            productManager.Add(new Product());
        }
    }
}
