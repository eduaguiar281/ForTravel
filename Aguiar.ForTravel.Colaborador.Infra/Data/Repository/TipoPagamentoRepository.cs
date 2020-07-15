using Aguiar.ForTravel.Colaborador.Domain.Interfaces;
using Aguiar.ForTravel.Colaborador.Domain.Models;
using Aguiar.ForTravel.Colaborador.Infra.Data.Context;
using Aguiar.ForTravel.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Infra.Data.Repository
{
    public class TipoPagamentoRepository:EfRepository<TipoPagamento>, ITipoPagamentoRepository
    {
        public TipoPagamentoRepository(IDataContext db, IUnitOfWork uow) : base(db, uow)
        {

        }
    }
}
