using Aguiar.ForTravel.Colaborador.Domain.Command.Colaborador;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Domain.Validations.Colaborador
{
    public class AtribuirTipoPagamentoColaboradorValidacoes: ColaboradorValidacoes<AtribuirTipoPagamentoColaboradorCommand>
    {
        public AtribuirTipoPagamentoColaboradorValidacoes()
        {
            ValidarId();
            ValidarListaTipoPagamento();
        }

        protected void ValidarListaTipoPagamento()
        {
            RuleFor(c => c.TiposPagamentoAdicionar)
                .Custom((t, context) =>
                {
                    if ((t == null) || (t.Count == 0))
                        context.AddFailure("Tipos de Pagamento", "Lista de Tipo de Pagamento do colaborador não foi informada!");
                });
        }
    }
}
