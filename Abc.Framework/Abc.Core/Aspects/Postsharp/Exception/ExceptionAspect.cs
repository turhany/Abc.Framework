using System;
using System.Reflection;
using Abc.Core.CrossCuttingConcerns.Logging;
using PostSharp.Aspects;

namespace Abc.Core.Aspects.Postsharp.Exception
{
    [Serializable]
    public class ExceptionAspect : OnExceptionAspect
    {
        [NonSerialized]
        private LoggerService _loggerService;
        private readonly Type _loggerType;

        public ExceptionAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType.BaseType != typeof(LoggerService))
                throw new System.Exception("Wrong Logger Type");

            _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            base.RuntimeInitialize(method);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            _loggerService?.Error(args.Exception);
        }
    }
}
