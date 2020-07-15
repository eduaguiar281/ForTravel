using System;
using Aguiar.ForTravel.Core.DomainObjects;
using FluentValidation.Results;

namespace Aguiar.ForTravel.Core.Messages.CommonMessages.DomainCommands
{
    public interface IDomainCommand<out T> where T:IAggregateRoot
    {
        T Data { get; }
        string MessageType { get; }
        Guid AggregateId { get; }
        DateTime Timestamp { get; }
        ValidationResult ValidationResult { get; set; }
    }
}