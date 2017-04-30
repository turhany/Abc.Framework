using System;
using System.Collections.Generic;
using Abc.Core.DataAccess;
using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<Product> RunSql();
        List<Product> Search(Func<Product, bool> deleg);
    }
}
