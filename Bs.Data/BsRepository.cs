using Bs.Data.Context;
using Bs.Data.Model.BaseModel;
using Bs.Utility;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Bs.Data
{
    /// <summary>
    /// Database işlemlerini yapan sınıf.
    /// </summary>
    public class BsRepository
    {
        private readonly DbContext dbContext;      //Database

        public BsRepository(BsContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException(nameof(dbContext));

            this.dbContext = dbContext;
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return dbContext.Set<T>();
        }

        public IQueryable<T> GetAll<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            DbSet<T> _dbSet = dbContext.Set<T>();
            return _dbSet.Where(predicate);
        }

        public T GetById<T>(long id) where T : class
        {
            DbSet<T> _dbSet = dbContext.Set<T>();
            return _dbSet.Find(id);
        }

        public T Get<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            DbSet<T> _dbSet = dbContext.Set<T>();
            return _dbSet.Where(predicate).SingleOrDefault();
        }

        public T Add<T>(T entity) where T : BaseEntityModel
        {
            DbSet<T> _dbSet = dbContext.Set<T>();
            T obj = _dbSet.Add(entity);
            GiveGuid();
            return obj;
        }

        public void Update<T>(T entity) where T : class
        {
            DbSet<T> _dbSet = dbContext.Set<T>();
            _dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete<T>(T entity) where T : BaseEntityModel
        {
            DbSet<T> _dbSet = dbContext.Set<T>();
            T fullEntity = GetById<T>(entity.Guid);
            _dbSet.Remove(fullEntity);
        }

        public void Delete<T>(int id) where T : BaseEntityModel
        {
            DbSet<T> _dbSet = dbContext.Set<T>();
            T fullEntity = GetById<T>(id);
            _dbSet.Remove(fullEntity);
        }

        public void GiveGuid()
        {
            var entries = dbContext.ChangeTracker.Entries<BaseEntityModel>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added && entry.Entity.Guid == 0)
                {
                    entry.Entity.Guid = BsGuid.GetGuid();
                }
            }
        }

        //private void FillBaseProperties<T>(T entity, CrudType crudType)
        //{
        //    if (crudType == CrudType.Create && entity.GetType().GetProperty("Guid") != null)
        //    {
        //        entity.GetType().GetProperty("Guid").SetValue(entity, BsGuid.GetGuid());
        //    }
        //    else if (crudType == CrudType.Update && entity.GetType().GetProperty("LastUpdated") != null)
        //    {
        //        long now = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
        //        entity.GetType().GetProperty("LastUpdated").SetValue(entity, now);
        //    }
        //}

        //public virtual void Delete(TEntity entityToDelete)
        //{
        //    if (dbContext.Entry(entityToDelete).State == EntityState.Detached)
        //    {
        //        _dbSet.Attach(entityToDelete);
        //    }
        //    _dbSet.Remove(entityToDelete);
        //}
    }
}