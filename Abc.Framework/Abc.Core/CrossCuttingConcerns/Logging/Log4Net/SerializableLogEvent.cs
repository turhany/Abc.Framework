
using log4net.Core;

namespace Abc.Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class SerializableLogEvent
    {
        private LoggingEvent _loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            this._loggingEvent = loggingEvent;
        }

        public string UserName => _loggingEvent.UserName;
        public object MessageObject => _loggingEvent.MessageObject;
    }
}
