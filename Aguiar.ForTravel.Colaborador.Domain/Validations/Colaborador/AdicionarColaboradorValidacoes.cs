using Aguiar.ForTravel.Colaborador.Domain.Command.Colaborador;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Domain.Validations.Colaborador
{
    public class AdicionarColaboradorValidacoes: ColaboradorValidacoes<AdicionarColaboradorCommand>
    {
        public AdicionarColaboradorValidacoes()
        {
            ValidarId();
            ValidarNome();
            ValidarApelido();
            ValidarEmail();
            ValidarFuncaoInclusao();
            ValidarTipoPagamentoInclusao();
        }

        protected void ValidarFuncaoInclusao()
        {
            RuleFor(c => c.FuncaoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Função do colaborador não foi informada!");

        }
        protected void ValidarTipoPagamentoInclusao()
        {
            RuleFor(c => c.TipoPagamentoIds)
                .Custom((t, context) => 
                {
                    if (t == null)
                    {
                        context.AddFailure("TiposPagamento", "Não foi informado não foi localizado!");
                        return;
                    }
                    if (t.Count == 0)
                        context.AddFailure("TiposPagamento", "Não foi informado não foi localizado!");
                    if (t.Where(g => g.Equals(Guid.Empty)).Any())
                        context.AddFailure("TiposPagamento", "Existem ids do Tipo de pagamento que não são válidos!");
                });
        }
    }
}
