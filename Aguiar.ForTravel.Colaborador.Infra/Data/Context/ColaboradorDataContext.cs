using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aguiar.ForTravel.Colaborador.Domain.Models;
using Aguiar.ForTravel.Core.Data;
using Aguiar.ForTravel.Core.DomainObjects;
using Aguiar.ForTravel.Core.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Aguiar.ForTravel.Colaborador.Infra.Data.Context
{
    public class ColaboradorDataContext: DbContext, IDataContext
    {
        public ColaboradorDataContext(DbContextOptions<ColaboradorDataContext> options) :base(options)
        {

        }


        public DbSet<Funcao> Funcoes { get; set; }
        public DbSet<TipoPagamento> TiposPagamento { get; set; }

        public DbSet<TiposPagamentoColaborador> TiposPagamentoColaborador { get; set; }

        public DbSet<Domain.Models.Colaborador> Colaboradores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(150)");

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ColaboradorDataContext).Assembly);
        }


        public async virtual new Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataAlteracao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync();
        }

        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : Entity
        {
            return base.Set<TEntity>();
        }

        public string GenerateCreateScript()
        {
            return this.Database.GenerateCreateScript();
        }

        public void Detach<TEntity>(TEntity entity) where TEntity : Entity
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var entityEntry = this.Entry(entity);
            if (entityEntry == null)
                return;

            //set the entity is not being tracked by the context
            entityEntry.State = EntityState.Detached;
        }

        public void UpdateEntityNotTracking<TEntity>(TEntity entity) where TEntity : Entity
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var original = base.Set<TEntity>().Find(entity.Id);
            if (original == null)
                throw new ArgumentException(nameof(original));

            Detach(original);

            this.Entry(entity).State = EntityState.Modified;
        }

    }
}
