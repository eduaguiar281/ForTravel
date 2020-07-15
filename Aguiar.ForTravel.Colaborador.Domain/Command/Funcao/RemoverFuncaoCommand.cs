using Aguiar.ForTravel.Colaborador.Domain.Validations.Funcao;
using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainCommands;

namespace Aguiar.ForTravel.Colaborador.Domain.Command.Funcao
{
    public class RemoverFuncaoCommand : DomainCommand<Models.Funcao>
    {
        public RemoverFuncaoCommand(Models.Funcao data) : base(data)
        {
        }


        public override bool EhValido()
        {
            ValidationResult = new RemoverFuncaoValidacoes().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}