using Aguiar.ForTravel.Colaborador.Domain.Command.TipoPagamento;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Domain.Validations.TipoPagamento
{
    public class AdicionarTipoPagamentoValidacao: TipoPagamentoValidacao<AdicionarTipoPagamentoCommand>
    {
        public AdicionarTipoPagamentoValidacao()
        {
            ValidarDescricao();
            ValidarId();
        }
    }
}
