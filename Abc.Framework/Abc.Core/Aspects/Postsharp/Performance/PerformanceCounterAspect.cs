using System;
using System.Diagnostics;
using System.Reflection;
using PostSharp.Aspects;

namespace Abc.Core.Aspects.Postsharp.Performance
{
    [Serializable]
    public class PerformanceCounterAspect : OnMethodBoundaryAspect
    {
        private readonly int _interval;

        [NonSerialized]
        private Stopwatch _stopwatch;

        public PerformanceCounterAspect(int interval)
        {
            _interval = interval;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            _stopwatch = Activator.CreateInstance<Stopwatch>();
            base.RuntimeInitialize(method);
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            _stopwatch.Start();
            base.OnEntry(args);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            _stopwatch.Stop();

            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine("Performance: {0}.{1} --> {2}", args.Method.DeclaringType.FullName, args.Method.Name, _stopwatch.Elapsed.TotalSeconds);
            }

            base.OnExit(args);
        }
    }
}
