using Aguiar.ForTravel.Colaborador.Domain.Command.TipoPagamento;

namespace Aguiar.ForTravel.Colaborador.Domain.Validations.TipoPagamento
{
    public class AlterarTipoPagamentoValidacao: TipoPagamentoValidacao<AlterarTipoPagamentoCommand>
    {

        public AlterarTipoPagamentoValidacao()
        {
            ValidarDescricao();
            ValidarId();
        }

    }
}
