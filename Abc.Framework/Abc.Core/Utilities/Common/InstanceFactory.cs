using Ninject;
using Ninject.Modules;

namespace Abc.Core.Utilities.Common
{
    public class InstanceFactory
    {
        public static T GetInstance<T>(NinjectModule module)
        {
            var kernel = new StandardKernel(module);
            return kernel.Get<T>();
        }
    }
}
