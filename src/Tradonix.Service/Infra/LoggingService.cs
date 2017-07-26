using System;
using Tradonix.Core.Entities;
using Tradonix.Core.Repository;
using Tradonix.Services.Infra;

namespace Tradonix.Service.Infra
{
    public class LoggingService : ILoggingService
    {
        private readonly ILoggingRepository _loggingRepository;
        public LoggingService(ILoggingRepository loggingRepository)
        {
            _loggingRepository = loggingRepository;
        }
        public void Log(string message, string detail = "", LogLevels logLevel = LogLevels.Spam, LogSource source = LogSource.UNKNOWN)
        {
            LogEntry log = new LogEntry { Timestamp = DateTime.UtcNow, Detail = detail, Message = message, LogLevelId = Convert.ToInt32(logLevel), LogType = source.ToString(), HostName = Environment.MachineName };
            _loggingRepository.Add(log);
            _loggingRepository.Commit();
        }
    }
}
