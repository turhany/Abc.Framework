using System;
using System.Linq;
using System.Reflection;
using Abc.Core.CrossCuttingConcerns.Logging;
using PostSharp.Aspects;

namespace Abc.Core.Aspects.Postsharp.Logging
{
    [Serializable]
    public class LogAspect : OnMethodBoundaryAspect
    {
        [NonSerialized]
        private LoggerService _loggerService;
        private readonly Type _loggerType;

        public LogAspect(Type loggerType)
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

        public override void OnEntry(MethodExecutionArgs args)
        {
            var logParameters = args.Method.GetParameters().Select(
                (t, i) => new LogParameter()
                {
                    Name = t.Name,
                    Type = t.ParameterType.Name,
                    Value = args.Arguments.GetArgument(i)
                }
            ).ToList();

            var logDetail = new LogDetail()
            {
                FullName = args.Method.DeclaringType != null ? null : args.Method.DeclaringType.Name,
                MethodName = args.Method.Name,
                LogParameters = logParameters
            };

            _loggerService.Debug(logDetail);

            base.OnEntry(args);
        }
    }
}
