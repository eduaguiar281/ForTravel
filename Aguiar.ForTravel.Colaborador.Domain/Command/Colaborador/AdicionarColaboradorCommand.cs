using Aguiar.ForTravel.Colaborador.Domain.Validations.Colaborador;
using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainCommands;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Domain.Command.Colaborador
{
    public class AdicionarColaboradorCommand: DomainCommand<Models.Colaborador>
    {
        public AdicionarColaboradorCommand(Models.Colaborador data, Guid funcaoId, IList<Guid> tipoPagamentoIds) : base(data)
        {
            FuncaoId = funcaoId;
            TipoPagamentoIds = tipoPagamentoIds;
        }
        
        public Guid? FuncaoId { get; private set; }
        public IList<Guid> TipoPagamentoIds { get; private set; }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarColaboradorValidacoes().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
