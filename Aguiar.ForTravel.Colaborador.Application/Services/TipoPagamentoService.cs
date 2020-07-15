using Aguiar.ForTravel.Colaborador.Application.Interfaces;
using Aguiar.ForTravel.Colaborador.Application.ViewModels;
using Aguiar.ForTravel.Colaborador.Domain.Command.TipoPagamento;
using Aguiar.ForTravel.Colaborador.Domain.Interfaces;
using Aguiar.ForTravel.Core.Communication.Mediator;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aguiar.ForTravel.Colaborador.Application.Services
{
    public class TipoPagamentoService: ITipoPagamentoService
    {
        private readonly IMapper _mapper;
        private ITipoPagamentoRepository _tipoPagamentoRepository;
        private IMediatorHandler _mediator;

        public TipoPagamentoService(IMapper mapper, ITipoPagamentoRepository tipoPagamentoRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _tipoPagamentoRepository = tipoPagamentoRepository;
            _mediator = mediator;

        }

        public async Task Adicionar(TipoPagamentoViewModel viewModel)
        {
            var adcionarCommand = _mapper.Map<AdicionarTipoPagamentoCommand>(viewModel);
            await _mediator.EnviarComando(adcionarCommand);
        }

        public async Task Alterar(TipoPagamentoViewModel viewModel)
        {
            var alterarCommand = _mapper.Map<AlterarTipoPagamentoCommand>(viewModel);
            await _mediator.EnviarComando(alterarCommand);
        }

        public async Task Remover(Guid id)
        {
            var viewModel = new TipoPagamentoViewModel
            {
                Id = id
            };
            var removerCommand = _mapper.Map<RemoverTipoPagamentoCommand>(viewModel);
            await _mediator.EnviarComando(removerCommand);
        }

        public IEnumerable<TipoPagamentoViewModel> ObterTodos()
        {
            return _tipoPagamentoRepository.GetAll().ProjectTo<TipoPagamentoViewModel>(_mapper.ConfigurationProvider);
        }

        public TipoPagamentoViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<TipoPagamentoViewModel>(_tipoPagamentoRepository.GetById(id));
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}
