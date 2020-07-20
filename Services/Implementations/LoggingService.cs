using Serilog;

namespace localapi.Services.Implementations
{
    public class LoggingService : ILoggingService
    {
        private ILogger Logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = new LoggerConfiguration()
                        .WriteTo.Seq("http://172.21.0.2:5341")
                        .CreateLogger();
                }
                return _logger;
            }
        }
        private ILogger _logger;
        public void WriteError(string arg)
        {
            Logger.Error(arg);
        }
    }
}

