using OnlineStore.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.Data_Repositories
{
    public class UserRepository : RepositoryBase<UserRepository, int>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
