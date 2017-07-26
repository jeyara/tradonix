using System;

namespace Tradonix.Core.Entities
{
    public class LogEntry : IEntityBase
    {
        public long Id { get; set; }
        public System.DateTimeOffset Timestamp { get; set; }
        public string HostName { get; set; }
        public string LogType { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
        public int LogLevelId { get; set; }
        public LogLevels LogLevel
        {
            get { return (LogLevels)LogLevelId; }
            set { LogLevelId = (int)value; }
        }
    }
}
