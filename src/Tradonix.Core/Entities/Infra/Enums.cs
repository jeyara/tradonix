namespace Tradonix.Core.Entities
{
    public enum SettingKeys
    {
        MailUserName,
        MailFrom,
        MailPassword,
        MailSMTPAddress,
        MailSMTPPort
    }

    public enum LogLevels
    {
        Spam = 100,
        Verbose = 200,
        Info = 300,
        Warning = 400,
        Error = 500,
    }

    public enum LogSource
    {
        UNKNOWN,
        INFRA,
        TRADE,
        BIGDATA,
        SECURITY,
        ML,
        UI
    }
}
