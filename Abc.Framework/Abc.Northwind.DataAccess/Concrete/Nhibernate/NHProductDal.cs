using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.DataAccess.Concrete.Nhibernate
{
    public class NHProductDal : IProductDal
    {
        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetList(Expression<Func<Product, bool>> filter = null)
        {
            return new List<Product>()
            {
                new Product() {ProductName = "elma"},
                new Product() {ProductName = "armut"},
                new Product() {ProductName = "üzüm"}
            };
        }

        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
