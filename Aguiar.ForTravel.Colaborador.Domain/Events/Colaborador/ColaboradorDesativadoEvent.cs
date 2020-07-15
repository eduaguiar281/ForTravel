using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Domain.Events.Colaborador
{
    public class ColaboradorDesativadoEvent: DomainEvent<Models.Colaborador>
    {
        public ColaboradorDesativadoEvent(Models.Colaborador data) : base(data)
        {

        }

    }
}
