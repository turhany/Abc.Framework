using Abc.Core.Utilities.Common;
using Abc.Northwind.Business.Abstract;
using Ninject.Modules;

namespace Abc.Northwind.Business.DependencyResolvers.Ninject
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().ToConstant(WcfProxy<IProductService>.CreateChannel());
        }
    }
}
