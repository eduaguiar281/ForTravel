using System;
using System.Linq;
using Aguiar.ForTravel.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;

namespace Aguiar.ForTravel.Core.Data
{
    public abstract class EfRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly IDataContext Db;
        protected readonly IUnitOfWork Uow;
        protected readonly DbSet<TEntity> DbSet;

        protected EfRepository(IDataContext db, IUnitOfWork uow)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
            Uow = uow;
        }
        public IUnitOfWork UnitOfWork => Uow;

        public IQueryable<T> Query<T>() where T : Entity
        {
            return Db.Set<T>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }
        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        protected virtual DbSet<T> GetDbSet<T>() where T:Entity
        {
            return Db.Set<T>();
        }


        public virtual void UpdateEntityNotTracking(TEntity obj)
        {
            Db.UpdateEntityNotTracking(obj);
        }

        public void Dispose()
        {
            Uow?.Dispose();
            Db?.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
