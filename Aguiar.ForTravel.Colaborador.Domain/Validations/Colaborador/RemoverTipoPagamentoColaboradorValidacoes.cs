using Aguiar.ForTravel.Colaborador.Domain.Command.Colaborador;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Domain.Validations.Colaborador
{
    public class RemoverTipoPagamentoColaboradorValidacoes: ColaboradorValidacoes<RemoverTipoPagamentoColaboradorCommand>
    {
        public RemoverTipoPagamentoColaboradorValidacoes()
        {
            ValidarId(); 
            ValidarListaTipoPagamento();
        }

        protected void ValidarListaTipoPagamento()
        {
            RuleFor(c => c.TiposPagamentoRemover)
                .Custom((t, context) =>
                {
                    if ((t == null) || (t.Count == 0))
                        context.AddFailure("Tipos de Pagamento", "Lista de Tipo de Pagamento a remover do colaborador não foi informada!");
                });
        }

    }
}
