using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Aguiar.ForTravel.Colaborador.Domain.Events.Funcao;
using MediatR;

namespace Aguiar.ForTravel.Colaborador.Domain.EventHandlers
{
    public class FuncaoEventHandler: 
        INotificationHandler<FuncaoAdicionadaEvent>,
        INotificationHandler<FuncaoRemovidaEvent>,
        INotificationHandler<FuncaoAlteradaEvent>
    {
        public Task Handle(FuncaoAdicionadaEvent notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Passando por {nameof(FuncaoAdicionadaEvent)} em {nameof(FuncaoEventHandler)}");
            return Task.CompletedTask;
        }

        public Task Handle(FuncaoRemovidaEvent notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Passando por {nameof(FuncaoRemovidaEvent)} em {nameof(FuncaoEventHandler)}");
            return Task.CompletedTask;
        }

        public Task Handle(FuncaoAlteradaEvent notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Passando por {nameof(FuncaoAdicionadaEvent)} em {nameof(FuncaoEventHandler)}");
            return Task.CompletedTask;
        }
    }
}