using Aguiar.ForTravel.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Domain.Models
{
    public class TiposPagamentoColaborador: Entity
    {
        protected TiposPagamentoColaborador()
        { }

        public TiposPagamentoColaborador(TipoPagamento tipoPagamento, Colaborador colaborador)
        {
            AlterarTipoPagamento(tipoPagamento);
            AlterarColaborador(colaborador);
        }


        public virtual TipoPagamento TipoPagamento { get; private set; }
        public Guid TipoPagamentoId { get; private set; }

        private void AlterarTipoPagamento(TipoPagamento tipoPagamento)
        {
            //TipoPagamento = tipoPagamento;
            TipoPagamentoId = tipoPagamento.Id;
        }

        public virtual Colaborador Colaborador { get; private set; }
        private void AlterarColaborador(Colaborador colaborador)
        {
            //Colaborador = colaborador;
            ColaboradorId = colaborador.Id;
        }

        public Guid ColaboradorId { get; private set; }
    }
}
