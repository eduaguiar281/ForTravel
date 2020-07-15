using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Aguiar.ForTravel.Colaborador.Domain.Events.TipoPagamento;
using MediatR;

namespace Aguiar.ForTravel.Colaborador.Domain.EventHandlers
{
    public class TipoPagamentoEventHandler :
        INotificationHandler<TipoPagamentoAdicionadoEvent>,
        INotificationHandler<TipoPagamentoAlteradoEvent>,
        INotificationHandler<TipoPagamentoRemovidoEvent>
    {
        public Task Handle(TipoPagamentoAlteradoEvent notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Passando por {nameof(TipoPagamentoAlteradoEvent)} em {nameof(TipoPagamentoEventHandler)}");
            return Task.CompletedTask;
        }

        public Task Handle(TipoPagamentoAdicionadoEvent notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Passando por {nameof(TipoPagamentoAdicionadoEvent)} em {nameof(TipoPagamentoEventHandler)}");
            return Task.CompletedTask;
        }

        public Task Handle(TipoPagamentoRemovidoEvent notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Passando por {nameof(TipoPagamentoRemovidoEvent)} em {nameof(TipoPagamentoEventHandler)}");
            return Task.CompletedTask;
        }
    }
}
