using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aguiar.ForTravel.Colaborador.Application.Interfaces;
using Aguiar.ForTravel.Colaborador.Application.ViewModels;
using Aguiar.ForTravel.Core.Communication.Mediator;
using Aguiar.ForTravel.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aguiar.ForTravel.Applications.WebAPI.Controllers
{
    [Route("api/cadastro-colaborador")]
    [ApiController]
    public class ColaboradorController : ApiControllerBase
    {
        private readonly IColaboradorService _colaboradorService;

        public ColaboradorController(IColaboradorService colaboradorService, INotificationHandler<DomainNotification> domainNotifications, IMediatorHandler mediator)
            : base(domainNotifications, mediator)
        {
            _colaboradorService = colaboradorService;
        }

        /// <summary>
        /// Método que retorna todos os Colaboradores em uma lista
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ListaColaboradorViewModel), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 401)]
        public IActionResult Get()
        {
            return Response(_colaboradorService.ObterListaColaborador());
        }

        /// <summary>
        /// Método que Localiza um Colaborador por Id
        /// </summary>
        /// <param name="id">Id do Colaborador</param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ColaboradorEdicaoViewModel), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 401)]
        public IActionResult Get(Guid id)
        {
            return Response(_colaboradorService.ObterColaboradorPorId(id));
        }

        /// <summary>
        /// Método que Cria um novo Colaborador
        /// </summary>
        /// <param name="viewModel">View Model do Colaborador</param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(typeof(ColaboradorEdicaoViewModel), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 401)]
        public async Task<IActionResult> Post([FromBody] ColaboradorEdicaoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarModelStateErrors();
                return Response(viewModel);
            }
            await _colaboradorService.AdicionarColaborador(viewModel);
            return Response(viewModel);
        }

        /// <summary>
        /// Atualiza um colaborador existente
        /// </summary>
        /// <param name="viewModel">View Model do Colaborador</param>
        /// <returns></returns>
        [HttpPut()]
        [ProducesResponseType(typeof(ColaboradorEdicaoViewModel), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 401)]
        public async Task<IActionResult> Put([FromBody] ColaboradorEdicaoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarModelStateErrors();
                return Response(viewModel);
            }
            await _colaboradorService.AlterarColaborador(viewModel);
            return Response(viewModel);
        }

        /// <summary>
        /// Ativa um colaborador
        /// </summary>
        /// <param name="id">Id do Colaborador</param>
        /// <returns></returns>
        [HttpGet("{id:guid}/ativar")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 401)]
        public async Task<IActionResult> Ativar(Guid id)
        {
            await _colaboradorService.AtivarColaborador(id);
            return Response();
        }

        /// <summary>
        /// Desativa um colaborador
        /// </summary>
        /// <param name="id">Id do Colaborador</param>
        /// <returns></returns>
        [HttpGet("{id:guid}/Desativar")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 401)]
        public async Task<IActionResult> Desativar(Guid id)
        {
            await _colaboradorService.DesativarColaborador(id);
            return Response(id);
        }

        /// <summary>
        /// Obtem os tipos de pagamento do Colaborador
        /// </summary>
        /// <param name="id">Id do Colaborador</param>
        /// <returns></returns>
        [HttpGet("{id:guid}/TiposPagamento")]
        [ProducesResponseType(typeof(IList<TipoPagamentoViewModel>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 401)]
        public IActionResult ObterTiposPagamento(Guid id)
        {
            return Response(_colaboradorService.ObterTipoPagamentoColaborador(id));
        }

        [HttpPost("{id:guid}/AtribuirFuncao")]
        [ProducesResponseType(typeof(FuncaoViewModel), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 401)]
        public async Task<IActionResult> AtribuirFuncao(Guid id, [FromBody] FuncaoViewModel funcaoViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarModelStateErrors();
                return Response(funcaoViewModel);
            }
            await _colaboradorService.AtribuirFuncaoAoColaborador(id, funcaoViewModel);
            return Response(funcaoViewModel);
        }

        [HttpPost("{id:guid}/AdicionarTipoPagamento")]
        [ProducesResponseType(typeof(TipoPagamentoViewModel), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 401)]
        public async Task<IActionResult> AdicionarTipoPagamanento(Guid id, [FromBody] TipoPagamentoViewModel tipoPagamento)
        {
            if (!ModelState.IsValid)
            {
                NotificarModelStateErrors();
                return Response(tipoPagamento);
            }
            await _colaboradorService.AtribuirTipoPagamentoAoColaborador(id, tipoPagamento);
            return Response(tipoPagamento);
        }

        [HttpPost("{id:guid}/RemoverTipoPagamento")]
        [ProducesResponseType(typeof(TipoPagamentoViewModel), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 401)]
        public async Task<IActionResult> RemoverTipoPagamento(Guid id, [FromBody] TipoPagamentoViewModel tipoPagamento)
        {
            if (!ModelState.IsValid)
            {
                NotificarModelStateErrors();
                return Response(tipoPagamento);
            }
            await _colaboradorService.RemoverTipoPagamentoDoColaborador(id, tipoPagamento);
            return Response(tipoPagamento);
        }

        [HttpPost("{id:guid}/AdicionarTiposPagamento")]
        [ProducesResponseType(typeof(TipoPagamentoViewModel), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 401)]
        public async Task<IActionResult> AdicionarTiposPagamanento(Guid id, [FromBody] IEnumerable<TipoPagamentoViewModel> tiposPagamento)
        {
            if (!ModelState.IsValid)
            {
                NotificarModelStateErrors();
                return Response(tiposPagamento);
            }
            await _colaboradorService.AtribuirTipoPagamentoAoColaborador(id, tiposPagamento);
            return Response(tiposPagamento);
        }

        [HttpPost("{id:guid}/RemoverTiposPagamento")]
        [ProducesResponseType(typeof(TipoPagamentoViewModel), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 401)]
        public async Task<IActionResult> RemoverTiposPagamento(Guid id, [FromBody] IEnumerable<TipoPagamentoViewModel> tiposPagamento)
        {
            if (!ModelState.IsValid)
            {
                NotificarModelStateErrors();
                return Response(tiposPagamento);
            }
            await _colaboradorService.RemoverTipoPagamentoDoColaborador(id, tiposPagamento);
            return Response(tiposPagamento);
        }

    }
}
