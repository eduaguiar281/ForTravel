using System;
using Aguiar.ForTravel.Colaborador.Domain.Validations.Funcao;
using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainCommands;

namespace Aguiar.ForTravel.Colaborador.Domain.Command.Funcao
{
    public class AlterarFuncaoCommand : DomainCommand<Models.Funcao>
    {
        public AlterarFuncaoCommand(Models.Funcao data)
            : base(data)
        {

        }

        

        public override bool EhValido()
        {
            ValidationResult = new AlterarFuncaoValidacoes().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}