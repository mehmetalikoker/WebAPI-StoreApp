using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace OnlineStore.ServiceHost.API.Filters
{
    public class FilterClass
    {
        public void JsonFormattersByMJ()
        {
            var jsonFormatters = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            jsonFormatters.UseDataContractJsonSerializer = true;
        }
    }
}