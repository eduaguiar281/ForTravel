using Aguiar.ForTravel.Core.DomainObjects;

namespace Aguiar.ForTravel.Core.Messages.CommonMessages.DomainCommands
{
    public abstract class DomainCommand<T> : Command, IDomainCommand<T> where T:IAggregateRoot
    {
        public T Data { get; protected set; }
        protected DomainCommand(T data)
            :base()
        {
            Data = data;
            AggregateId = data.Id;
        }
    }
}