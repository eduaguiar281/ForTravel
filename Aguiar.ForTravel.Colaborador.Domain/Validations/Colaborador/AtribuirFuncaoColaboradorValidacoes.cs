using Aguiar.ForTravel.Colaborador.Domain.Command.Colaborador;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Domain.Validations.Colaborador
{
    public class AtribuirFuncaoColaboradorValidacoes: ColaboradorValidacoes<AtribuirFuncaoColaboradorCommand>
    {
        public AtribuirFuncaoColaboradorValidacoes()
        {
            ValidarId();
            ValidarNovaFuncao();
        }

        protected void ValidarNovaFuncao()
        {
            RuleFor(c => c.NovaFuncao)
                .NotNull()
                .WithMessage("Função do colaborador não foi informada!");
            RuleFor(c => c.NovaFuncao.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Função do colaborador não foi informada!");
        }

    }
}
