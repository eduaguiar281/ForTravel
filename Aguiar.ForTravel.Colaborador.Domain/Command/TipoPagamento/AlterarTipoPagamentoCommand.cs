using Aguiar.ForTravel.Colaborador.Domain.Validations.TipoPagamento;
using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainCommands;

namespace Aguiar.ForTravel.Colaborador.Domain.Command.TipoPagamento
{
    public class AlterarTipoPagamentoCommand: DomainCommand<Models.TipoPagamento>
    {
        public AlterarTipoPagamentoCommand(Models.TipoPagamento data) : base(data)
        { }

        public override bool EhValido()
        {
            ValidationResult = new AlterarTipoPagamentoValidacao().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
