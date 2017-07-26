using System;
using System.Linq;
using Tradonix.Core.Entities;
using Tradonix.EFRepository;

namespace Tradonix.EFRepository
{
    public static class DbInitializer
    {
        private static TradonixContext context;
        public static void Initialize(TradonixContext ctx)
        {

            context = ctx;

            InitializeData();

        }

        private static void InitializeData()
        {
            #region Settings Data Prep
            if (!context.Setting.Any())
            {
                // create host api urls
                context.Setting.AddRange(new Setting[]
                {
                    new Setting { Key = SettingKeys.MailSMTPAddress.ToString(), Value ="smtp.sendgrid.net" },
                    new Setting { Key = SettingKeys.MailSMTPPort.ToString(), Value ="587" },
                    new Setting { Key = SettingKeys.MailUserName.ToString(), Value ="azure_9aa4dfe90b02fb6804037ac3fc38a71a@azure.com" },
                    new Setting { Key = SettingKeys.MailPassword.ToString(), Value ="abc123" },
                    new Setting { Key = SettingKeys.MailFrom.ToString(), Value ="tradonix@jeyara.com" },
                });

                context.SaveChanges();
            }
            #endregion
        }

        private static int[] GenerateRandomNumbersForSum(int sum, int nums)
        {
            int max = sum / nums;
            Random rand = new Random();
            int newNum = 0;
            int[] ar = new int[nums];
            for (int i = 0; i < nums - 1; i++)
            {
                newNum = rand.Next(max);
                ar[i] = newNum;
                sum -= newNum;
                max = sum / (nums - i - 1);
            }
            ar[nums - 1] = sum;

            return ar;
        }
    }
}
