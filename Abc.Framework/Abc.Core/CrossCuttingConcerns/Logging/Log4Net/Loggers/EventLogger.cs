using log4net;

namespace Abc.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class EventLogger : LoggerService
    {
        public EventLogger() : base(LogManager.GetLogger("EventLogger"))
        {
        }
    }
}
