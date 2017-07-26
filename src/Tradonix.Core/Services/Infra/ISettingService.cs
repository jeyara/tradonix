using Tradonix.Core.Entities;

namespace Tradonix.Services.Infra
{
    public interface ISettingService
    {
        void SetSetting<T>(SettingKeys key, T val);

        T GetSetting<T>(SettingKeys key);

        void DeleteSetting(SettingKeys key);

        void SetSetting(SettingKeys key, string val);

        string GetSetting(SettingKeys key);

    }
}
