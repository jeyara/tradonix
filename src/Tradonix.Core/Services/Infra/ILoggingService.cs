using Tradonix.Core.Entities;
using System;

namespace Tradonix.Services.Infra
{
    public interface ILoggingService
    {
        void Log(string message, string detail = "", LogLevels logLevel = LogLevels.Spam, LogSource source = LogSource.UNKNOWN);
    }
}
