using Aguiar.ForTravel.Colaborador.Application.Interfaces;
using Aguiar.ForTravel.Colaborador.Application.ViewModels;
using Aguiar.ForTravel.Core.Communication.Mediator;
using Aguiar.ForTravel.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aguiar.ForTravel.Applications.WebAPI.Controllers
{
    [Route("cadastro-tipo-pagamento")]
    public class TipoPagamentoController: ApiControllerBase
    {
        private readonly ITipoPagamentoService _tipoPagamentoService;

        public TipoPagamentoController(ITipoPagamentoService tipoPagamentoService, INotificationHandler<DomainNotification> domainNotifications, IMediatorHandler mediator)
            : base(domainNotifications, mediator)
        {
            _tipoPagamentoService = tipoPagamentoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_tipoPagamentoService.ObterTodos());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            return Response(_tipoPagamentoService.ObterPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TipoPagamentoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarModelStateErrors();
                return Response(viewModel);
            }
            await _tipoPagamentoService.Adicionar(viewModel);
            return Response(viewModel);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TipoPagamentoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarModelStateErrors();
                return Response(viewModel);
            }
            await _tipoPagamentoService.Alterar(viewModel);
            return Response(viewModel);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _tipoPagamentoService.Remover(id);
            return Response();
        }

    }
}
