using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using OnlineStore.Core;
using Castle.DynamicProxy;
using System.Web.Http.Controllers;
using OnlineStore.Core.Common.Contracts;
using System.Data.Entity;
using OnlineStore.Data;
using OnlineStore.Data.Contracts;
using OnlineStore.Core.Common.Caching;

namespace OnlineStore.ServiceHost.API.Core
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterInterceptors(container);

            RegisterHttpControllers(container);

            RegisterConfigurationHelpers(container);

            RegisterEngines(container);

            RegisterEntityFrameworkContexts(container);

            RegisterDataRepositories(container);

            RegisterCacheProviders(container);

            RegisterLoggers(container);
        }

        private void RegisterLoggers(IWindsorContainer container)
        {
            container.Register(DependencyContainer.Descriptor
                .BasedOn<ILogger>()
                .WithServiceBase()
                .LifestyleSingleton());
        }

        private void RegisterCacheProviders(IWindsorContainer container)
        {
            container.Register(DependencyContainer.Descriptor
                .BasedOn<ICacheProvider>()
                .WithServiceBase()
                .LifestyleSingleton());
        }

        private void RegisterDataRepositories(IWindsorContainer container)
        {
            container.Register(DependencyContainer.Descriptor
                .BasedOn(typeof(IRepository<,>))
                .WithService
                .AllInterfaces()
                .LifestylePerWebRequest());
        }

        private void RegisterEntityFrameworkContexts(IWindsorContainer container)
        {
            container.Register(Component.For<DbContext>().ImplementedBy<OnlineStoreContext>().LifestylePerWebRequest());
        }

        private void RegisterEngines(IWindsorContainer container)
        {
            container.Register(DependencyContainer.Descriptor
                  .BasedOn<IBusinessEngine>()
                  .WithService
                  .AllInterfaces()
                  .LifestylePerWebRequest());
        }

        private void RegisterConfigurationHelpers(IWindsorContainer container)
        {
            container.Register(DependencyContainer.Descriptor
                .BasedOn<IConfigurationHelper>()
                .WithServiceBase()
                .LifestyleSingleton());
        }

        private void RegisterHttpControllers(IWindsorContainer container)
        {
            container.Register(DependencyContainer.Descriptor
                .BasedOn<IHttpController>()
                .WithService
                .Self()
                .LifestylePerWebRequest());
        }

        public void RegisterInterceptors(IWindsorContainer container)
        {
            container.Register(
                DependencyContainer.Descriptor
                .BasedOn<IInterceptor>()
                .WithService
                .Self()
                .LifestylePerWebRequest());
        }




    }
}