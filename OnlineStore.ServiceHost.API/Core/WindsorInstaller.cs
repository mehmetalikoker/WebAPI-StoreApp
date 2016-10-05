using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace OnlineStore.ServiceHost.API.Core
{
    public class WindsorInstaller : IWindsorInstaller
    {


        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterInterceptors
            throw new NotImplementedException();
        }

        public void RegisterInterceptors
        {

        }
    }
}