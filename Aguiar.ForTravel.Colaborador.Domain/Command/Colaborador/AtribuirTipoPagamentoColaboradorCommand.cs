using Aguiar.ForTravel.Colaborador.Domain.Validations.Colaborador;
using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Domain.Command.Colaborador
{
    public class AtribuirTipoPagamentoColaboradorCommand: DomainCommand<Models.Colaborador>
    {
        public AtribuirTipoPagamentoColaboradorCommand(Models.Colaborador data, IList<Models.TipoPagamento> tiposPagamentoAdicionar)
            :base(data)
        {
            TiposPagamentoAdicionar = tiposPagamentoAdicionar;
        }

        public IList<Models.TipoPagamento> TiposPagamentoAdicionar { get; private set; }

        public override bool EhValido()
        {
            ValidationResult = new AtribuirTipoPagamentoColaboradorValidacoes().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
