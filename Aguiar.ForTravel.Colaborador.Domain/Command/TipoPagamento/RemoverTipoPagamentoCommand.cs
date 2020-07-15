using Aguiar.ForTravel.Colaborador.Domain.Validations.TipoPagamento;
using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainCommands;

namespace Aguiar.ForTravel.Colaborador.Domain.Command.TipoPagamento
{
    public class RemoverTipoPagamentoCommand: DomainCommand<Models.TipoPagamento>
    {
        public RemoverTipoPagamentoCommand(Models.TipoPagamento data) : base(data)
        { }

        public override bool EhValido()
        {
            ValidationResult = new RemoverTipoPagamentoValidacao().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
