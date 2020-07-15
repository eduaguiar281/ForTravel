using Aguiar.ForTravel.Colaborador.Application.Interfaces;
using Aguiar.ForTravel.Colaborador.Application.ViewModels;
using Aguiar.ForTravel.Core.Communication.Mediator;
using Aguiar.ForTravel.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Aguiar.ForTravel.Applications.WebAPI.Controllers
{
    [Route("cadastro-funcao")]
    public class FuncaoController: ApiControllerBase
    {
        private readonly IFuncaoService _funcaoService;

        public FuncaoController(IFuncaoService funcaoService, INotificationHandler<DomainNotification> domainNotifications, IMediatorHandler mediator)
            :base(domainNotifications, mediator)
        {
            _funcaoService = funcaoService;
        }
        
        [HttpGet]
        //[Route("cadastro-funcao")]
        public IActionResult Get()
        {
            return Response(_funcaoService.ObterTodos());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            return Response(_funcaoService.ObterPorId(id));
        }

        [HttpPost]
        //[Route("cadastro-funcao")]
        public async Task<IActionResult> Post([FromBody] FuncaoViewModel funcaoViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarModelStateErrors();
                return Response(funcaoViewModel);
            }
            await _funcaoService.Adicionar(funcaoViewModel);
            return Response(funcaoViewModel);
        }

        [HttpPut]
        //[Route("cadastro-funcao")]
        public async Task<IActionResult> Put([FromBody] FuncaoViewModel funcaoViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarModelStateErrors();
                return Response(funcaoViewModel);
            }
            await _funcaoService.Alterar(funcaoViewModel);
            return Response(funcaoViewModel);
        }

        [HttpDelete]
        //[Route("cadastro-funcao")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _funcaoService.Remover(id);
            return Response();
        }
    }
}
