using OnlineStore.Business.Contracts;
using OnlineStore.Core.Common.Contracts.ResponseMessages;
using OnlineStore.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Core.Common.Contracts.RequestMessages;
using OnlineStore.Data.Entities;
using System.Data.Entity;

namespace OnlineStore.Business
{
    public class ProductEngine : BusinessEngineBase, IProductEngine
    {
        private readonly IProductRepository _productRepository;

        public ProductEngine(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #region IProduct Members
        public Task<ProductResponse> CreateAsync(ProductCreateRequest categoryCreateRequest)
        {
            return base.ExecuteWithExceptionHandledOperation(async () =>
            {
                var product = Mapper.Map<Product>(categoryCreateRequest);

                _productRepository.Add(product);

                await _productRepository.SaveChangeAsync();

                return Mapper.Map<ProductResponse>(product);
            });
        }

        public Task DeleteAsync(int id)
        {
            return base.ExecuteWithExceptionHandledOperation(async () =>
            {
                await _productRepository.Delete(id);

                await _productRepository.SaveChangeAsync();
            });
        }

        public Task<List<ProductResponse>> GetAllAsync(int skip, int take)
        {
            return base.ExecuteWithExceptionHandledOperation(async () =>
            {
                var products = _productRepository.GetAll(skip, take);

                return Mapper.Map<List<ProductResponse>>(await products.ToListAsync());
            });
        }

        public Task<ProductResponse> GetAsync(int id)
        {
            return base.ExecuteWithExceptionHandledOperation(async () =>
            {
                var product = await _productRepository.GetAsync(id);

                // prodcut entity sini product response a çeviriyoruz.
                return Mapper.Map<ProductResponse>(product);
            });
        }

        public Task<ProductResponse> UpdateAsync(ProductUpdateRequest productUpdateRequest)
        {
            return base.ExecuteWithExceptionHandledOperation(async () =>
            {
                var product = Mapper.Map<Product>(productUpdateRequest);

                _productRepository.Update(product);

                await _productRepository.SaveChangeAsync();

                return Mapper.Map<ProductResponse>(product);
            });
        } 
        #endregion
    }
}
