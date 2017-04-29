using System.Collections.Generic;
using Abc.Core.DataAccess.EntityFramework;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EFCategoryDal : EFEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
        public List<Product> RunSql()
        {
            using (NorthwindContext context  = new NorthwindContext())
            {
                //custom sql çalıştıran kodlar
            }

            return null;
        }
    }
}
