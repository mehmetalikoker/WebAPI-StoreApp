using OnlineStore.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineStore.ServiceHost.API.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryEngine _categoryEngine;

        public CategoryController(ICategoryEngine categoryEngine)
        {
            _categoryEngine = categoryEngine;
        }
    }
}
