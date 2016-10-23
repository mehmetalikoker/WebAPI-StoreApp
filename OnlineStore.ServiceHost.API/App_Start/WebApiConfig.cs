using OnlineStore.ServiceHost.API.Core;
using OnlineStore.ServiceHost.API.Filters;
using OnlineStore.ServiceHost.API.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Filters;

namespace OnlineStore.ServiceHost.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MessageHandlers.Add(new ApiResponseHandler());
            config.Services.Replace(typeof(IHttpControllerActivator), new WindsorHttpControllerActivator());

            // Filters
            //config.Filters.Add(new JsonFormattersByMJ(new ));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
