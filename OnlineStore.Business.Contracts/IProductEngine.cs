using OnlineStore.Core.Common.Contracts;
using OnlineStore.Core.Common.Contracts.RequestMessages;
using OnlineStore.Core.Common.Contracts.ResponseMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.Contracts
{
    public interface IProductEngine : IBusinessEngine
    {
        Task<ProductResponse> GetAsync(int id);
        Task<ProductResponse> CreateAsync(ProductCreateRequest categoryCreateRequest);
        Task<ProductResponse> UpdateAsync(ProductUpdateRequest categoryUpdateRequest);
        Task DeleteAsync(int id);
        Task<List<ProductResponse>> GetAllAsync(int skip, int take);
    }
}
