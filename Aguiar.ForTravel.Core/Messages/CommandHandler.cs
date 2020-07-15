using Aguiar.ForTravel.Core.Communication.Mediator;
using Aguiar.ForTravel.Core.Data;
using Aguiar.ForTravel.Core.Messages.CommonMessages.Notifications;
using MediatR;
using System.Threading.Tasks;

namespace Aguiar.ForTravel.Core.Messages
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IMediatorHandler _mediatorHandler;
        private readonly DomainNotificationHandler _domainNotifications;

        public CommandHandler(IUnitOfWork uow, IMediatorHandler mediatorHandler, INotificationHandler<DomainNotification> domainNotification)
        {
            _unitOfWork = uow;
            _mediatorHandler = mediatorHandler;
            _domainNotifications = (DomainNotificationHandler)domainNotification;
        }

        protected async Task NotificarErrosValidacao(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public async Task<bool> Commit()
        {
            if (_domainNotifications.TemNotificacao()) return false;
            var success = await _unitOfWork.Commit();
            if (success) return true;

            await _mediatorHandler.PublicarNotificacao(new DomainNotification("Commit", "Ocorreu um problema ao gravar dados."));
            return false;
        }

    }
}
