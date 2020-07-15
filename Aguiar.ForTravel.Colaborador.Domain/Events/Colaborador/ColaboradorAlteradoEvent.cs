using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Domain.Events.Colaborador
{
    public class ColaboradorAlteradoEvent : DomainEvent<Models.Colaborador>
    {
        public ColaboradorAlteradoEvent(Models.Colaborador data)
            :base(data)
        {

        }
    }
}
