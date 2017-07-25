using System;
using Tradonix.Core.Entities;
using Tradonix.Core.Enums;
using Tradonix.Core.Repository;

namespace Tradonix.EFRepository.Repositories
{
    public class SettingRepository : EntityBaseRepository<Setting>, ISettingRepository
    {
        public SettingRepository(TradonixContext context)
            : base(context)
        { }

        public Setting GetSetting(SettingKeys key)
        {
            return GetSingle(t => t.Key == key.ToString());
        }
    }
}
