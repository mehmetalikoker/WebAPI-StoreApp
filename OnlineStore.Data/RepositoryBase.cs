using OnlineStore.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using OnlineStore.Data.Entities;

namespace OnlineStore.Data
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : EntityBase<TKey>
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TKey id)
        {
            throw new NotImplementedException();
        }

        //order by yapmadan yani sıralamadan verilerde skip yapılamaz, entity framework hata verir.
        public IQueryable<TEntity> GetAll(int skip, int take)
        {
            return _dbSet.OrderBy(q=> q.Id).Skip(skip).Take(take);
        }

        public IQueryable<TEntity> GetAll(int skip, int take, Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll(skip, take).Where(predicate);
        }

        public Task<TEntity> GetAsync(TKey id)
        {
            return _dbSet.FindAsync(id);
        }

        public Task SaveChangeAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
