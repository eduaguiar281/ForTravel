using Aguiar.ForTravel.Core.Data;
using System;
using System.Collections.Generic;

namespace Aguiar.ForTravel.Colaborador.Domain.Interfaces
{
    public interface IColaboradorRepository : IRepository<Models.Colaborador>
    {
        bool FuncaoExiste(Guid id);
        bool TipoPagamentoExiste(Guid id);
        void AdicionarTiposPagamentos(Models.Colaborador colaborador);
        void RemoverTipoPagamento(Guid id);
        void RemoverTipoPagamento(IEnumerable<Guid> id);
    }
}