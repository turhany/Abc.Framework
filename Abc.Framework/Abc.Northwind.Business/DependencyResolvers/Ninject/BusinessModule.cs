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
            this.Bind<IProductService>().To<ProductManager>().InSingletonScope();//her keze aynı instance ver, performance etkisi büyük
            this.Bind<IProductDal>().To<EFProductDal>().InSingletonScope();
            //this.Bind<IProductDal>().To<NHProductDal>();
            this.Bind<DbContext>().To<NorthwindContext>();

            this.Bind(typeof(IQueryableRepository<>)).To(typeof(EFQueryableRepository<>));

            this.Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();//her keze aynı instance ver, performance etkisi büyük
            this.Bind<ICategoryDal>().To<EFCategoryDal>().InSingletonScope();

            this.Bind<NHibernateHelper>().To<SqlNHibernateHelper>();
        }
    }
}
