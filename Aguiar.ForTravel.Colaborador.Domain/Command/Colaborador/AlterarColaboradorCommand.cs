using Aguiar.ForTravel.Colaborador.Domain.Validations.Colaborador;
using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Domain.Command.Colaborador
{
    public class AlterarColaboradorCommand : DomainCommand<Models.Colaborador>
    {
        public AlterarColaboradorCommand(Models.Colaborador data) : base(data)
        { }

        public override bool EhValido()
        {
            ValidationResult = new AlterarColaboradorValidacoes().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
