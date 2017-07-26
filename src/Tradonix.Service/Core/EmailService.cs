using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Tradonix.Core.Entities;
using Tradonix.Core.Helper;
using Tradonix.Core.Services;

namespace Tradonix.Service.Core
{
    public class EmailService : IEmailService
    {
        private readonly ISettingService _settingService;
        public EmailService(ISettingService settingService)
        {
            this._settingService = settingService;
        }

        public async Task SendEmailAsync(string body, string subjectLine, List<string> toAddress)
        {
            var myMessage = new MailMessage();

            toAddress.ForEach(t => myMessage.To.Add(t));
            myMessage.From = new MailAddress(_settingService.GetSetting(SettingKeys.MailFrom),  _settingService.GetSetting(SettingKeys.MailFrom));
            myMessage.Subject = subjectLine;
            myMessage.Body = body;
            myMessage.IsBodyHtml = false;

            var credentials = new NetworkCredential(
                       _settingService.GetSetting(SettingKeys.MailUserName),
                       _settingService.GetSetting(SettingKeys.MailPassword)
                       );

            SmtpClient smtpClient = new SmtpClient(_settingService.GetSetting(SettingKeys.MailSMTPAddress), Convert.ToInt32(_settingService.GetSetting(SettingKeys.MailSMTPPort)));
            smtpClient.Credentials = credentials;

            // Send the email.
            if (smtpClient != null)
            {
               await smtpClient.SendMailAsync(myMessage); ;
            }
            else
            {
                await Task.FromResult(0);
            }

        }
        public async Task SendEmailAsync(string body, string subjectLine, string toAddress)
        {
            await SendEmailAsync(body, subjectLine, new List<string> { toAddress });
        }
    }
}
