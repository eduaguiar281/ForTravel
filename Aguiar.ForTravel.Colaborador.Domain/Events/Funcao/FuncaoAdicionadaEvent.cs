using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainEvents;

namespace Aguiar.ForTravel.Colaborador.Domain.Events.Funcao
{
    public class FuncaoAdicionadaEvent: DomainEvent<Models.Funcao>
    {
        public FuncaoAdicionadaEvent(Models.Funcao data) : base(data)
        {
        }
    }
}