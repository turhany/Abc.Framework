using System;
using System.Collections.Generic;
using System.Linq;
using Abc.Core.DataAccess.NHibernate;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.Entities.Concrete;
using NHibernate.Linq;

namespace Abc.Northwind.DataAccess.Concrete.Nhibernate
{
    public class NHProductDal : HHEntityRepositoryBase<Product>, IProductDal
    {
        private readonly NHibernateHelper _nHibernateHelper;

        public NHProductDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public List<Product> RunSql()
        {
            //custom sql çalıştıran kodlar

            return null;
        }

        public List<Product> Search(Func<Product, bool> deleg)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                return session.Query<Product>().Where(deleg).ToList();
            }
        }
    }
}
