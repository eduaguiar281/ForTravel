using System;

namespace Aguiar.ForTravel.Core.DomainObjects
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}