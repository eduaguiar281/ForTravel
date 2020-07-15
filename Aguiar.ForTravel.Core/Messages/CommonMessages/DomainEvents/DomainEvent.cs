using System;
using Aguiar.ForTravel.Core.DomainObjects;


namespace Aguiar.ForTravel.Core.Messages.CommonMessages.DomainEvents
{
    public abstract class DomainEvent<T> : Event where T:IAggregateRoot
    {

        public T Data { get; protected set; }

        protected DomainEvent(T data)
        {
            AggregateId = data.Id;
            Data = data;
        }
    }
}
