using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainEvents;

namespace Aguiar.ForTravel.Colaborador.Domain.Events.TipoPagamento
{
    public class TipoPagamentoAlteradoEvent: DomainEvent<Models.TipoPagamento>
    {
        public TipoPagamentoAlteradoEvent(Models.TipoPagamento data)
            : base(data)
        {

        }

    }
}
