using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Domain.Validations.TipoPagamento
{
    public abstract class TipoPagamentoValidacao<T> : AbstractValidator<T> where T : IDomainCommand<Models.TipoPagamento>
    {
        protected void ValidarDescricao()
        {
            RuleFor(f => f.Data.Descricao)
                .NotEmpty().WithMessage("Descrição não foi inforamda!");
        }

        protected void ValidarId()
        {
            RuleFor(c => c.Data.Id)
                .NotEqual(Guid.Empty);
        }

    }
}
