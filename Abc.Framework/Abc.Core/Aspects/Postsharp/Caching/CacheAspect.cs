using System;
using System.Linq;
using System.Reflection;
using Abc.Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;

namespace Abc.Core.Aspects.Postsharp.Caching
{
    [Serializable]
    public class CacheAspect : MethodInterceptionAspect //Runtime PostSharpAspect base
    {
        private readonly Type _cacheType;
        private readonly int _cacheMinute;
        private ICacheManager _manager;

        public CacheAspect(Type cacheType, int cacheMinute = 60)
        {
            _cacheType = cacheType;
            _cacheMinute = cacheMinute;
        }

        //Methoda girmeden runtime anında araya girer
        public override void RuntimeInitialize(MethodBase method)
        {
            if (!typeof(ICacheManager).IsAssignableFrom(_cacheType))
                throw new System.Exception("Wrong Cache Manager.");

            _manager = (ICacheManager)Activator.CreateInstance(_cacheType);
            base.RuntimeInitialize(method);
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var methodName = string.Format("{0}.{1}.{2}",
                args.Method.ReflectedType.Namespace,
                args.Method.ReflectedType.Name,
                args.Method.Name);

            var arguments = args.Arguments.ToList();
            //Abc.Northwind.Bussines.Concrete.ProductManager.GetByCategoryId(3) gibi bir key oluşur
            var key = $"{methodName}({arguments.Select(x => x?.ToString() ?? "<Null>")})";

            if (_manager.IsAdd(key))
            {
                //Method devam ettirme methodtan çık, postsharp ile return
                args.ReturnValue = _manager.Get<object>(key);
                return;
            }

            base.OnInvoke(args);
            _manager.Add(key, args.ReturnValue, _cacheMinute);
        }
    }
}
