using log4net;

namespace Abc.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class ConsoleLogger : LoggerService
    {
        public ConsoleLogger() : base(LogManager.GetLogger("ConsoleLogger"))
        {
        }
    }
}
