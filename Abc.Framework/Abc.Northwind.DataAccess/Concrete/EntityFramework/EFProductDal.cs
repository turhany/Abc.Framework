using System.Collections.Generic;
using Abc.Core.DataAccess.EntityFramework;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EFProductDal : EFEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<Product> RunSql()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //custom sql çalıştıran kodlar
            }

            return null;
        }
    }
}
