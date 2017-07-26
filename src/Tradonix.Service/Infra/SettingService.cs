using Tradonix.Core.Entities;
using Tradonix.Core.Repository;
using Tradonix.Core.Services;
using System.Linq;
using Newtonsoft.Json;

namespace Tradonix.Service.Infra
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;

        public SettingService(ISettingRepository settingRepository)
        {
            this._settingRepository = settingRepository;
        }

        public void DeleteSetting(SettingKeys key)
        {
            var setting = _settingRepository.FindBy(t => t.Key == key.ToString()).FirstOrDefault();

            if (setting != null)
            {
                _settingRepository.Delete(setting);
                _settingRepository.Commit();
            }
        }

        public T GetSetting<T>(SettingKeys key)
        {
            var setting = _settingRepository.FindBy(t => t.Key == key.ToString()).FirstOrDefault();

            if (setting != null)
            {
                return JsonDeserialize<T>(setting.Value);
            }
            else
            {
                return default(T);
            }
        }

        public string GetSetting(SettingKeys key)
        {
            var setting = _settingRepository.FindBy(t => t.Key == key.ToString()).FirstOrDefault();

            if (setting != null)
            {
                return setting.Value;
            }
            else
            {
                return string.Empty;
            }
        }

        public void SetSetting<T>(SettingKeys key, T val)
        {
            var setting = _settingRepository.FindBy(t => t.Key == key.ToString()).FirstOrDefault();

            if (setting != null)
            {
                setting.Value = JsonSerializer<T>(val);
                _settingRepository.Commit();
            }
            else
            {
                var newSetting = new Setting();
                newSetting.Key = key.ToString();
                newSetting.Value = JsonSerializer<T>(val);
                _settingRepository.Add(newSetting);
                _settingRepository.Commit();
            }
        }

        public void SetSetting(SettingKeys key, string val)
        {
            var setting = _settingRepository.FindBy(t => t.Key == key.ToString()).FirstOrDefault();

            if (setting != null)
            {
                setting.Value = val;
                _settingRepository.Commit();
            }
            else
            {
                var newSetting = new Setting();
                newSetting.Key = key.ToString();
                newSetting.Value = val;
                _settingRepository.Add(newSetting);
                _settingRepository.Commit();
            }
        }

        private string JsonSerializer<T>(T t)
        {
            return JsonConvert.SerializeObject(t);

            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            //MemoryStream ms = new MemoryStream();
            //ser.WriteObject(ms, t);
            //string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            //ms.Close();
            //return jsonString;
        }

        public static T JsonDeserialize<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);

            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            //MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            //T obj = (T)ser.ReadObject(ms);
            //return obj;
        }


    }
}
