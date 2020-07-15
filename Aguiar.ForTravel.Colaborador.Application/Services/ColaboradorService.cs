using Aguiar.ForTravel.Colaborador.Application.Interfaces;
using Aguiar.ForTravel.Colaborador.Application.ViewModels;
using Aguiar.ForTravel.Colaborador.Domain.Command.Colaborador;
using Aguiar.ForTravel.Colaborador.Domain.Command.TipoPagamento;
using Aguiar.ForTravel.Colaborador.Domain.Interfaces;
using Aguiar.ForTravel.Colaborador.Domain.Models;
using Aguiar.ForTravel.Core.Communication.Mediator;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aguiar.ForTravel.Colaborador.Application.Services
{
    public class ColaboradorService : IColaboradorService
    {
        private readonly IMapper _mapper;
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IMediatorHandler _mediator;

        public ColaboradorService(IMapper mapper, IColaboradorRepository colaboradorRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _colaboradorRepository = colaboradorRepository;
            _mediator = mediator;
        }

        public async Task AdicionarColaborador(ColaboradorEdicaoViewModel viewModel)
        {
            var adicionarCommand = _mapper.Map<AdicionarColaboradorCommand>(viewModel);
            await _mediator.EnviarComando(adicionarCommand);
        }

        public async Task AtribuirTipoPagamentoAoColaborador(Guid id, TipoPagamentoViewModel tipoPagamento)
        {
            var colaborador = _colaboradorRepository.GetById(id);
            var listaTiposPagamento = new List<TipoPagamento>
            {
                _mapper.Map<TipoPagamento>(tipoPagamento)
            };
            var adicionarTipoPagamentoCommand = new AtribuirTipoPagamentoColaboradorCommand(colaborador, listaTiposPagamento);
            await _mediator.EnviarComando(adicionarTipoPagamentoCommand);
        }

        public async Task AlterarColaborador(ColaboradorEdicaoViewModel viewModel)
        {
            var alterarCommand = _mapper.Map<AlterarColaboradorCommand>(viewModel);
            await _mediator.EnviarComando(alterarCommand);
        }

        public async Task AtivarColaborador(Guid id)
        {
            var colaborador = _colaboradorRepository.GetById(id);
            var ativarCommand = new AtivarColaboradorCommand(colaborador);
            await _mediator.EnviarComando(ativarCommand);
        }

        public async Task AtribuirFuncaoAoColaborador(Guid id, FuncaoViewModel funcao)
        {
            var colaborador = _colaboradorRepository.GetById(id);
            var atribuidFuncaoCommand = new AtribuirFuncaoColaboradorCommand(colaborador, _mapper.Map<Funcao>(funcao));
            await _mediator.EnviarComando(atribuidFuncaoCommand);
        }

        public async Task DesativarColaborador(Guid id)
        {
            var colaborador = _colaboradorRepository.GetById(id);
            var ativarCommand = new AtivarColaboradorCommand(colaborador);
            await _mediator.EnviarComando(ativarCommand);
        }

        public ColaboradorEdicaoViewModel ObterColaboradorPorId(Guid id)
        {
            return _mapper.Map<ColaboradorEdicaoViewModel>(_colaboradorRepository.GetById(id));
        }

        public ListaColaboradorViewModel ObterListaColaborador()
        {
            var result = new ListaColaboradorViewModel()
            {
                Lista = _colaboradorRepository.GetAll().ProjectTo<ColaboradorItemListaViewModel>(_mapper.ConfigurationProvider).ToList()
            };
            return result;
        }

        public IList<TipoPagamentoViewModel> ObterTipoPagamentoColaborador(Guid id)
        {
            var colaborador = _mapper.Map<ColaboradorEdicaoViewModel>(_colaboradorRepository.GetById(id));
            return colaborador.TiposPagamento;
        }

        public async Task RemoverTipoPagamentoDoColaborador(Guid id, TipoPagamentoViewModel tipoPagamento)
        {
            var colaborador = _colaboradorRepository.GetById(id);
            var listaTiposPagamento = new List<TipoPagamento>
            {
                _mapper.Map<TipoPagamento>(tipoPagamento)
            };
            var adicionarTipoPagamentoCommand = new RemoverTipoPagamentoColaboradorCommand(colaborador, listaTiposPagamento);
            await _mediator.EnviarComando(adicionarTipoPagamentoCommand);
        }
        public async Task AtribuirTipoPagamentoAoColaborador(Guid id, IEnumerable<TipoPagamentoViewModel> tiposPagamento)
        {
            var colaborador = _colaboradorRepository.GetById(id);
            var listaTiposPagamento = new List<TipoPagamento>(tiposPagamento.Select(s => _mapper.Map<TipoPagamento>(s)));
            var adicionarTipoPagamentoCommand = new AtribuirTipoPagamentoColaboradorCommand(colaborador, listaTiposPagamento);
            await _mediator.EnviarComando(adicionarTipoPagamentoCommand);
        }

        public async Task RemoverTipoPagamentoDoColaborador(Guid id, IEnumerable<TipoPagamentoViewModel> tiposPagamento)
        {
            var colaborador = _colaboradorRepository.GetById(id);
            var listaTiposPagamento = new List<TipoPagamento>(tiposPagamento.Select(s => _mapper.Map<TipoPagamento>(s)));
            var removerTipoPagamentoColaboradorCommand = new RemoverTipoPagamentoColaboradorCommand(colaborador, listaTiposPagamento);
            await _mediator.EnviarComando(removerTipoPagamentoColaboradorCommand);
        }

}
}
