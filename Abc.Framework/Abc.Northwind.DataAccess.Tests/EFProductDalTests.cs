using Abc.Northwind.DataAccess.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Northwind.DataAccess.Tests
{
    [TestClass]
    public class EFProductDalTests
    {
        [TestMethod]
        public void AllProductsShouldBeListed()
        {
            EFProductDal productDal = new EFProductDal();

            Assert.AreEqual(77, productDal.GetList().Count);
        }
    }
}
