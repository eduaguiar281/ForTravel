using System.Threading.Tasks;
using Aguiar.ForTravel.Core.Messages;
using Aguiar.ForTravel.Core.Messages.CommonMessages.Notifications;

namespace Aguiar.ForTravel.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<bool> EnviarComando<T>(T comando) where T : Command;
        Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification;

    }
}