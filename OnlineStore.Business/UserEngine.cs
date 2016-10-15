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
/// Engine lerde respositoryler ile konuşacağız.
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

        public Task<UserResponse> GetAsync(int id)
        {
            return base.ExecuteWithExceptionHandledOperation(async () =>
            {
                var user = await _userRepository.GetAsync(id);

                // user entity sini user response çeviriyoruz.
                return Mapper.Map<UserResponse>(user);
            });
        }
    }
}
