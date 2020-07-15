using Aguiar.ForTravel.Colaborador.Domain.Validations.Colaborador;
using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Domain.Command.Colaborador
{
    public class AtivarColaboradorCommand: DomainCommand<Models.Colaborador>
    {
        public AtivarColaboradorCommand(Models.Colaborador data) : base(data)
        { }

        public override bool EhValido()
        {
            ValidationResult = new AtivarColaboradorValidacoes().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
