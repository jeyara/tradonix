using Microsoft.Practices.Unity;
using Tradonix.Core.Helper;
using Tradonix.Core.Repository;
using Tradonix.Core.Services;
using Tradonix.EFRepository;
using Tradonix.EFRepository.Repositories;
using Tradonix.Service.CoreServices;
using Tradonix.Service.Service.Core;

namespace Tradonix.Web
{
    public static class UnityConfig
    {
        public static IUnityContainer RegisterComponents()
        {

            var container = new UnityContainer();

            container.RegisterType<TradonixContext>(new PerRequestLifetimeManager());

            container.RegisterType<ILoggingRepository, LoggingRepository>();
            container.RegisterType<ISettingRepository, SettingRepository>();

            container.RegisterType<IEncryptionService, EncryptionService>();
            container.RegisterType<ILoggingService, LoggingService>();
            container.RegisterType<ISettingService, SettingService>();

            container.RegisterType<IEmailService, EmailService>();
        }
    }
}