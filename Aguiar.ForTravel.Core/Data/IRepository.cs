using Aguiar.ForTravel.Core.DomainObjects;
using System;
using System.Linq;

namespace Aguiar.ForTravel.Core.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity: Entity
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);

        void UpdateEntityNotTracking(TEntity obj);

        void Remove(Guid id);

        int SaveChanges();
        IQueryable<T> Query<T>() where T : Entity;

        IUnitOfWork UnitOfWork { get; }

    }
}