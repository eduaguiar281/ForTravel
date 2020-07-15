using Aguiar.ForTravel.Colaborador.Domain.Validations.Colaborador;
using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Domain.Command.Colaborador
{
    public class AtribuirFuncaoColaboradorCommand : DomainCommand<Models.Colaborador>
    {
        public AtribuirFuncaoColaboradorCommand(Models.Colaborador data, Models.Funcao novaFuncao) : base(data)
        {
            NovaFuncao = novaFuncao;
        }

        public Models.Funcao NovaFuncao { get; private set; }

        public override bool EhValido()
        {
            ValidationResult = new AtribuirFuncaoColaboradorValidacoes().Validate(this);
            return ValidationResult.IsValid;
        }
       

    }
}
