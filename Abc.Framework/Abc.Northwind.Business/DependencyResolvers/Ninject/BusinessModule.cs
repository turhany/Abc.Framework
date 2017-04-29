using System.Data.Entity;
using Abc.Core.DataAccess;
using Abc.Core.DataAccess.EntityFramework;
using Abc.Core.DataAccess.NHibernate;
using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Business.Concrete;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.DataAccess.Concrete.EntityFramework;
using Abc.Northwind.DataAccess.Concrete.Nhibernate.Helpers;
using Ninject.Modules;

namespace Abc.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            //InSingletonScope > her keze aynı instance ver, performance etkisi büyük

            //EF özelinde tanımlamalar
            this.Bind<DbContext>().To<NorthwindContext>();
            this.Bind(typeof(IQueryableRepository<>)).To(typeof(EFQueryableRepository<>));
            this.Bind<IProductDal>().To<EFProductDal>().InSingletonScope();
            this.Bind<ICategoryDal>().To<EFCategoryDal>().InSingletonScope();

            //Nhibernate özelinde tanımalamalar
            this.Bind<NHibernateHelper>().To<SqlNHibernateHelper>();
            //this.Bind<IProductDal>().To<NHProductDal>();

            //Genel manager tanımlamaları
            this.Bind<IProductService>().To<ProductManager>().InSingletonScope();
            this.Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
        }
    }
}
