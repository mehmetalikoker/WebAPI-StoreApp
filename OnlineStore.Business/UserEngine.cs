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

/// <summary>
/// Engine içinde de respository yapısı ile konuşacağız.
/// </summary>
namespace OnlineStore.Business
{
    public class UserEngine : BusinessEngineBase, IUserEngine
    {
        private readonly IUserRepository _userRepository;

        public UserEngine(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        // Post
        public Task<UserResponse> CreateAsync(UserCreateRequest request)
        {
            return base.ExecuteWithExceptionHandledOperation(async () =>
            {
                var user = Mapper.Map<User>(request);

                _userRepository.Add(user);

                await _userRepository.SaveChangeAsync();

                return Mapper.Map<UserResponse>(user);
            });
        }


        // Delete 
        public Task DeleteAsync(int id)
        {
            return base.ExecuteWithExceptionHandledOperation(async () =>
            {

                await _userRepository.Delete(id);

                await _userRepository.SaveChangeAsync();
            });
        }

        public Task<UserResponse> GetAsync(int id)
        {
            return base.ExecuteWithExceptionHandledOperation(async () =>
            {
                var user = await _userRepository.GetAsync(id);

                // user entity sini user response çeviriyoruz.
                return Mapper.Map<UserResponse>(user);
            });
        }


        // Put
        public Task<UserResponse> UpdateAsync(UserUpdateRequest request)
        {
            return base.ExecuteWithExceptionHandledOperation(async () =>
            {
                var user = Mapper.Map<User>(request);

                _userRepository.Update(user);

                await _userRepository.SaveChangeAsync();

                return Mapper.Map<UserResponse>(user);
            });
        }
    }
}
