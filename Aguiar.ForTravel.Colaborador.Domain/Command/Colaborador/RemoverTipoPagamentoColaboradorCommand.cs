using Aguiar.ForTravel.Colaborador.Domain.Validations.Colaborador;
using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Domain.Command.Colaborador
{
    public class RemoverTipoPagamentoColaboradorCommand: DomainCommand<Models.Colaborador>
    {
        public RemoverTipoPagamentoColaboradorCommand(Models.Colaborador data, IList<Models.TipoPagamento> tiposPagamento)
            :base(data)
        {
            TiposPagamentoRemover = tiposPagamento;
        }

        public IList<Models.TipoPagamento> TiposPagamentoRemover { get; private set; }

        public override bool EhValido()
        {
            ValidationResult = new RemoverTipoPagamentoColaboradorValidacoes().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
