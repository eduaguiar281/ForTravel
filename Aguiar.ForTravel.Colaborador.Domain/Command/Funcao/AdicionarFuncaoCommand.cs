using Aguiar.ForTravel.Colaborador.Domain.Validations;
using Aguiar.ForTravel.Colaborador.Domain.Validations.Funcao;
using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainCommands;

namespace Aguiar.ForTravel.Colaborador.Domain.Command.Funcao
{
    public class AdicionarFuncaoCommand: DomainCommand<Models.Funcao>
    {
        public AdicionarFuncaoCommand(Models.Funcao data) : base(data)
        { }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarFuncaoValidacoes().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
