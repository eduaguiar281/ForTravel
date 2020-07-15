using Aguiar.ForTravel.Core.Communication.Mediator;
using Aguiar.ForTravel.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Aguiar.ForTravel.Applications.WebAPI.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        private readonly DomainNotificationHandler _domainNotificationHandler;
        private readonly IMediatorHandler _mediatorHandler;
        public ApiControllerBase(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediatorHandler)
        {
            _domainNotificationHandler = (DomainNotificationHandler)notifications;
            _mediatorHandler = mediatorHandler;

        }

        protected IEnumerable<DomainNotification> Notifications => _domainNotificationHandler.ObterNotificacoes();

        protected bool OperacaoEhValida()
        {
            return (!_domainNotificationHandler.TemNotificacao());
        }

        protected new IActionResult Response(object result = null)
        {
            if (OperacaoEhValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }
            return BadRequest(new
            {
                success = false,
                errors = _domainNotificationHandler.ObterNotificacoes().Select(n => n.Value)
            });
        }

        protected void NotificarModelStateErrors()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(string.Empty, erroMsg);
            }
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediatorHandler.PublicarNotificacao(new DomainNotification(codigo, mensagem));
        }


        /*
        TODO: Implementar Identity 
        protected void AddIdentityErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                NotifyError(result.ToString(), error.Description);
            }
        }
         
         */
    }
}