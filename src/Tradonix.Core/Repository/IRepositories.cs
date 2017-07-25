using Tradonix.Core.Entities;

namespace Tradonix.Core.Repository
{
    public interface ILoggingRepository : IEntityBaseRepository<LogEntry> { }

    public interface ISettingRepository : IEntityBaseRepository<Setting>
    {
        Setting GetSetting(SettingKeys key);
    }
}
