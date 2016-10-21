using OnlineStore.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Core.Common.Contracts.ResponseMessages;
using OnlineStore.Data.Contracts;
using OnlineStore.Core.Common.Contracts.RequestMessages;
using OnlineStore.Data.Entities;
using System.Data.Entity;

namespace OnlineStore.Business
{
    public class CategoryEngine : BusinessEngineBase, ICategoryEngine
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryEngine(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        #region ICategoryEngine Members

        public Task<CategoryResponse> GetAsync(int id)
        {
            return base.ExecuteWithExceptionHandledOperation(async () =>
            {
                var category = await _categoryRepository.GetAsync(id);

                // category entity sini category response ye çeviriyoruz.
                return Mapper.Map<CategoryResponse>(category);
            });
        }

        public Task<CategoryResponse> CreateAsync(CategoryCreateRequest categoryCreateRequest)
        {
            return base.ExecuteWithExceptionHandledOperation(async () =>
            {
                var category = Mapper.Map<Category>(categoryCreateRequest);

                _categoryRepository.Add(category);

                await _categoryRepository.SaveChangeAsync();

                return Mapper.Map<CategoryResponse>(category);
            });
        }

        public Task<CategoryResponse> UpdateAsync(CategoryUpdateRequest categoryUpdateRequest)
        {
            return base.ExecuteWithExceptionHandledOperation(async () =>
            {
                var category = Mapper.Map<Category>(categoryUpdateRequest);

                _categoryRepository.Update(category);

                await _categoryRepository.SaveChangeAsync();

                return Mapper.Map<CategoryResponse>(category);
            });
        }

        public Task DeleteAsync(int id)
        {
            return base.ExecuteWithExceptionHandledOperation(async () =>
            {
                await _categoryRepository.Delete(id);

                await _categoryRepository.SaveChangeAsync();
            });
        }

        public Task<List<CategoryResponse>> GetAllAsync(int skip, int take)
        {
            return base.ExecuteWithExceptionHandledOperation(async () =>
            {
                var categories = _categoryRepository.GetAll(skip,take);

                return Mapper.Map<List<CategoryResponse>>(await categories.ToListAsync());
            });
        }


        #endregion
    }
}
