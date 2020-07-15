using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainEvents;


namespace Aguiar.ForTravel.Colaborador.Domain.Events.TipoPagamento
{
    public class TipoPagamentoAdicionadoEvent: DomainEvent<Models.TipoPagamento>
    {
        public TipoPagamentoAdicionadoEvent(Models.TipoPagamento data)
            :base(data)
        {

        }
    }
}
