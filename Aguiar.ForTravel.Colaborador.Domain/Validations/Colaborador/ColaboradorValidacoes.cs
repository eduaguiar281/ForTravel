using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Domain.Validations.Colaborador
{
    public class ColaboradorValidacoes<T> : AbstractValidator<T> where T : IDomainCommand<Models.Colaborador>
    {
        protected void ValidarNome()
        {
            RuleFor(c => c.Data.Nome).NotEmpty().WithMessage("Nome do colaborador não foi inforamdo!");
        }

        protected void ValidarApelido()
        {
            RuleFor(c => c.Data.Apelido).NotEmpty().WithMessage("Apelido do colaborador não foi inforamdo!");
        }

        protected void ValidarEmail()
        {
            RuleFor(c => c.Data.Email).EmailAddress().WithMessage("E-mail do colaborador não é válido!");
        }

        protected void ValidarFuncao()
        {
            RuleFor(c => c.Data.FuncaoId).NotEqual(Guid.Empty).WithMessage("Função do colaborador não foi informada!");
        }

        protected void ValidarTipoPagamento()
        {
            RuleFor(c => 
              c.Data.TiposPagamento)
                .Must(t => t.Count > 0).WithMessage("Não foi informado nenhum tipo de pagamento para o colaborador!");
        }

        protected void ValidarId()
        {
            RuleFor(c => c.Data.Id)
                .NotEqual(Guid.Empty).WithMessage("Id Inválido!");
        }

    }
}
