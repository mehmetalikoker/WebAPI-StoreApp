using OnlineStore.Business.Contracts;
using OnlineStore.Core.Common.Contracts.RequestMessages;
using OnlineStore.Core.Common.Contracts.ResponseMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OnlineStore.ServiceHost.API.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductEngine _productEngine;

        public ProductController(IProductEngine productEngine)
        {
            _productEngine = productEngine;
        }

        public Task<ProductResponse> Get(int id)
        {
            return _productEngine.GetAsync(id);
        }

        public Task<ProductResponse> Create([FromBody] ProductCreateRequest request)
        {
            return _productEngine.CreateAsync(request);
        }

        public Task<ProductResponse> Put([FromBody] ProductUpdateRequest request)
        {
            return _productEngine.UpdateAsync(request);
        }

        public Task Delete(int id)
        {
            return _productEngine.DeleteAsync(id);
        }

        public Task<List<ProductResponse>> GetAll(int skip, int take)
        {
            return _productEngine.GetAllAsync(skip, take);
        }
    }
}
