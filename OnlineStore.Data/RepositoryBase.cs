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
    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>, IDisposable
        where TEntity : EntityBase<TKey> 
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        // sadece bir kez dispose edilme kontrolü
        private bool _disposed;

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        #region IRepository Members
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public async Task Delete(TKey id)
        {
            var entity = await GetAsync(id);
            Delete(entity);
        }

        //order by yapmadan yani sıralamadan verilerde skip yapılamaz, entity framework hata verir.
        public IQueryable<TEntity> GetAll(int skip, int take)
        {
            return _dbSet.OrderBy(q => q.Id).Skip(skip).Take(take);
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
            return _dbContext.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        #endregion

        #region IDispossible Members
        ~RepositoryBase()
        {
            Dispose(false);
        }

        //işlem sonrasında ilgili DbContext nesnesini siliyoruz.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
                _dbContext.Dispose();
            _disposed = true;
        }


        #endregion
    }
}
