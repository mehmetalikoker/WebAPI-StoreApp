using OnlineStore.Data.Contracts;
using OnlineStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OnlineStore.Data.Data_Repositories
{
    public class ProductRepository : RepositoryBase<Product, int>, IProductRepository
    {
        public ProductRepository(DbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
