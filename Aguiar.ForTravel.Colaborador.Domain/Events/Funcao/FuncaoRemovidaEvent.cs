using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainEvents;

namespace Aguiar.ForTravel.Colaborador.Domain.Events.Funcao
{
    public class FuncaoRemovidaEvent : DomainEvent<Models.Funcao>
    {
        public FuncaoRemovidaEvent(Models.Funcao data) : base(data)
        {
        }
    }
}