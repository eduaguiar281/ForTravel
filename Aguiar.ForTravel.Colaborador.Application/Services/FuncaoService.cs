using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aguiar.ForTravel.Colaborador.Application.Interfaces;
using Aguiar.ForTravel.Colaborador.Application.ViewModels;
using Aguiar.ForTravel.Colaborador.Domain.Command.Funcao;
using Aguiar.ForTravel.Colaborador.Domain.Interfaces;
using Aguiar.ForTravel.Core.Communication.Mediator;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Aguiar.ForTravel.Colaborador.Application.Services
{
    public partial class FuncaoService: IFuncaoService
    {
        private readonly IMapper _mapper;
        private readonly IFuncaoRepository _funcaoRepository;
        private readonly IMediatorHandler _mediator;

        public FuncaoService(IMapper mapper, IFuncaoRepository funcaoRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _funcaoRepository = funcaoRepository;
            _mediator = mediator;
        }

        public async Task Adicionar(FuncaoViewModel funcaoViewModel)
        {
            var adcionarCommand = _mapper.Map<AdicionarFuncaoCommand>(funcaoViewModel);
            await _mediator.EnviarComando(adcionarCommand);
        }

        public async Task Alterar(FuncaoViewModel funcaoViewModel)
        {
            var alterarCommand = _mapper.Map<AlterarFuncaoCommand>(funcaoViewModel);
            await _mediator.EnviarComando(alterarCommand);
        }

        public async Task Remover(Guid id)
        {
            var funcaoViewModel = new FuncaoViewModel
            {
                Id = id
            };
            var removerCommand = _mapper.Map<RemoverFuncaoCommand>(funcaoViewModel);
            await _mediator.EnviarComando(removerCommand);
        }

        public IEnumerable<FuncaoViewModel> ObterTodos()
        {
            return _funcaoRepository.GetAll().ProjectTo<FuncaoViewModel>(_mapper.ConfigurationProvider);
        }

        public FuncaoViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<FuncaoViewModel>(_funcaoRepository.GetById(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
