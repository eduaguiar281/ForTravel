using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Domain.Events.TipoPagamento
{
    public class TipoPagamentoRemovidoEvent: DomainEvent<Models.TipoPagamento>
    {
        public TipoPagamentoRemovidoEvent(Models.TipoPagamento data)
            :base(data)
        {

        }
    }
}
