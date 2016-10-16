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

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        #region IRepository Members

        // Create
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }


        // Delete
        public void Delete(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }
        public async Task Delete(TKey id)
        {
            var entity = await GetAsync(id);
            Delete(entity);
        }

        /// <summary>
        /// Get Metotları
        /// Order by yapmadan verilerde skip yapılamaz.
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
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


        // Save
        public Task SaveChangeAsync()
        {
            return _dbContext.SaveChangesAsync();
        }


        // Update
        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        #endregion

        #region IDispossible Members

        // Sadece bir kez dispose edilme kontrolü sağlayalım.
        private bool _disposed;
        private void Dispose(bool disposing)
        {
            if (disposing)
                _dbContext.Dispose();

            _disposed = true;
        }

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

        #endregion
    }
}
