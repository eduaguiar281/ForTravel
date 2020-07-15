using Aguiar.ForTravel.Colaborador.Domain.Validations.TipoPagamento;
using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainCommands;

namespace Aguiar.ForTravel.Colaborador.Domain.Command.TipoPagamento
{
    public class AdicionarTipoPagamentoCommand : DomainCommand<Models.TipoPagamento>
    {
        public AdicionarTipoPagamentoCommand(Models.TipoPagamento data) : base(data)
        { }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarTipoPagamentoValidacao().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
