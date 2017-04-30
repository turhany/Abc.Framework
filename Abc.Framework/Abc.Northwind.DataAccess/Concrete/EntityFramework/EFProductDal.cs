using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Product> Search(Func<Product, bool> deleg)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Products.Where(deleg).ToList();
            }
        }
    }
}
