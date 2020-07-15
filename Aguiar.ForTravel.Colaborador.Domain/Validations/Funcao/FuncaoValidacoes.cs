using System;
using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainCommands;
using FluentValidation;

namespace Aguiar.ForTravel.Colaborador.Domain.Validations.Funcao
{
    public abstract class FuncaoValidacoes<T>: AbstractValidator<T>  where T: IDomainCommand<Models.Funcao>
    {
        protected void ValidarDescricao()
        {
            RuleFor(f => f.Data.Descricao)
                .NotEmpty().WithMessage("Descrição não foi inforamda!");
        }

        protected void ValidarLimiteOrcamento()
        {
            RuleFor(f => f.Data.LimiteOrcamentoViagem)
                .GreaterThanOrEqualTo(LimiteMinimo)
                .WithMessage($"Orçamento da Viagem deve ser maior que {LimiteMinimo:N}");
        }

        protected void ValidarId()
        {
            RuleFor(c => c.Data.Id)
                .NotEqual(Guid.Empty);
        }

        protected static decimal LimiteMinimo => 1000.00M;
    }
}
