using Aguiar.ForTravel.Colaborador.Domain.Events.Colaborador;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aguiar.ForTravel.Colaborador.Domain.EventHandlers
{
    public class ColaboradorEventHandler : 
        INotificationHandler<ColaboradorDesativadoEvent>,
        INotificationHandler<ColaboradorAtivadoEvent>,
        INotificationHandler<ColaboradorAdicionadoEvent>,
        INotificationHandler<ColaboradorAlteradoEvent>,
        INotificationHandler<ColaboradorFuncaoAtribuidaEvent>,
        INotificationHandler<ColaboradorTipoPagamentoAtribuidoEvent>,
        INotificationHandler<ColaboradorTipoPagamentoRemovidoEvent>

    {
        public Task Handle(ColaboradorDesativadoEvent notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Passando por {nameof(ColaboradorDesativadoEvent)} em {nameof(ColaboradorEventHandler)}");
            return Task.CompletedTask;
        }

        public Task Handle(ColaboradorAtivadoEvent notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Passando por {nameof(ColaboradorAtivadoEvent)} em {nameof(ColaboradorEventHandler)}");
            return Task.CompletedTask;
        }

        public Task Handle(ColaboradorAdicionadoEvent notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Passando por {nameof(ColaboradorAdicionadoEvent)} em {nameof(ColaboradorEventHandler)}");
            return Task.CompletedTask;
        }

        public Task Handle(ColaboradorAlteradoEvent notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Passando por {nameof(ColaboradorAlteradoEvent)} em {nameof(ColaboradorEventHandler)}");
            return Task.CompletedTask;
        }

        public Task Handle(ColaboradorFuncaoAtribuidaEvent notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Passando por {nameof(ColaboradorFuncaoAtribuidaEvent)} em {nameof(ColaboradorEventHandler)}");
            return Task.CompletedTask;
        }

        public Task Handle(ColaboradorTipoPagamentoAtribuidoEvent notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Passando por {nameof(ColaboradorTipoPagamentoAtribuidoEvent)} em {nameof(ColaboradorEventHandler)}");
            return Task.CompletedTask;
        }

        public Task Handle(ColaboradorTipoPagamentoRemovidoEvent notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Passando por {nameof(ColaboradorTipoPagamentoRemovidoEvent)} em {nameof(ColaboradorEventHandler)}");
            return Task.CompletedTask;
        }
    }
}
