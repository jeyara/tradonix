using Microsoft.Practices.Unity;
using Tradonix.Core.Repository;
using Tradonix.Core.Services;
using Tradonix.EFRepository;
using Tradonix.EFRepository.Repositories;
using System.Web.Mvc;
using System.Web.Http;
using Tradonix.Services.Infra;
using Tradonix.Service.Infra;
using Tradonix.Service;
using Tradonix.Core.Services.Meta;
using Tradonix.Service.Meta;
using Tradonix.Core.Services.Transaction;
using Tradonix.Service.Transaction;

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

            container.RegisterType<IMetaService, MetaService>();
            container.RegisterType<ITransactionService, TransactionService>();

            return container;
        }

        public static void Initialise()
        {
            var container = RegisterComponents();
            DependencyResolver.SetResolver(new Microsoft.Practices.Unity.Mvc.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}