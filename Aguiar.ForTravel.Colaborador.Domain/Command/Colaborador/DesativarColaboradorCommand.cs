using Aguiar.ForTravel.Colaborador.Domain.Validations.Colaborador;
using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainCommands;


namespace Aguiar.ForTravel.Colaborador.Domain.Command.Colaborador
{
    public class DesativarColaboradorCommand : DomainCommand<Models.Colaborador>
    {
        public DesativarColaboradorCommand(Models.Colaborador data) : base(data)
        { }

        public override bool EhValido()
        {
            ValidationResult = new DesativarColaboradorValidacoes().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
