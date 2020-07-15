using System;
using System.Collections.Generic;
using System.Text;
using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainEvents;

namespace Aguiar.ForTravel.Colaborador.Domain.Events.Funcao
{
    public class FuncaoAlteradaEvent: DomainEvent<Models.Funcao>
    {
        public FuncaoAlteradaEvent(Models.Funcao data) : base(data)
        {

        }
    }
}
