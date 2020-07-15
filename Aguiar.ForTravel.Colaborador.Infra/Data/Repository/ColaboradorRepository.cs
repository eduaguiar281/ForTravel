using Aguiar.ForTravel.Colaborador.Domain.Interfaces;
using Aguiar.ForTravel.Colaborador.Domain.Models;
using Aguiar.ForTravel.Colaborador.Infra.Data.Context;
using Aguiar.ForTravel.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aguiar.ForTravel.Colaborador.Infra.Data.Repository
{
    public class ColaboradorRepository: EfRepository<Domain.Models.Colaborador>, IColaboradorRepository
    {
        private readonly ColaboradorDataContext _dataContext;
        public ColaboradorRepository(IDataContext db, IUnitOfWork uow) : base(db, uow)
        {
            _dataContext = (db as ColaboradorDataContext);
        }

        public bool FuncaoExiste(Guid id)
        {
            return _dataContext.Funcoes.Any(f => f.Id == id);
        }

        public bool TipoPagamentoExiste(Guid id)
        {
            return _dataContext.TiposPagamento.Any(f => f.Id == id);
        }

        public void AdicionarTiposPagamentos(Domain.Models.Colaborador colaborador)
        {
            foreach (var tipo in colaborador.TiposPagamento)
            {
                var tipoDb = _dataContext.TiposPagamentoColaborador.Find(tipo.Id);
                if (tipoDb == null)
                    _dataContext.TiposPagamentoColaborador.Add(tipo);
            }

            //var tipoPagamentoColaborador = new TiposPagamentoColaborador(tipoPagamento, colaborador);
            //_dataContext.TiposPagamentoColaborador.Add(tipoPagamentoColaborador);
        }
        public void RemoverTipoPagamento(Guid id)
        {
            var tipoPagamentoColaborador = this.Query<TiposPagamentoColaborador>().FirstOrDefault(i => i.Id == id);
            _dataContext.TiposPagamentoColaborador.Remove(tipoPagamentoColaborador);
        }

        public override Domain.Models.Colaborador GetById(Guid id)
        {
            var colaborador = DbSet.FirstOrDefault(c => c.Id == id);
            _dataContext.Entry(colaborador).Collection(c => c.TiposPagamento).Load();
            if (colaborador.FuncaoId != null)
                _dataContext.Entry(colaborador).Reference(c => c.Funcao).Load();
            return colaborador;
        }

        public void RemoverTipoPagamento(IEnumerable<Guid> id)
        {
            foreach (var key in id)
                RemoverTipoPagamento(key);
        }
    }
}
