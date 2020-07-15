using System.Threading;
using System.Threading.Tasks;
using Aguiar.ForTravel.Colaborador.Domain.Command.Funcao;
using Aguiar.ForTravel.Colaborador.Domain.Interfaces;
using Aguiar.ForTravel.Core.Communication.Mediator;
using Aguiar.ForTravel.Core.Data;
using Aguiar.ForTravel.Core.Messages;
using Aguiar.ForTravel.Core.Messages.CommonMessages.Notifications;
using MediatR;
using System;
using System.Diagnostics;

namespace Aguiar.ForTravel.Colaborador.Domain.CommandHandlers
{
    public class FuncaoCommandHandler : CommandHandler,
        IRequestHandler<AdicionarFuncaoCommand, bool>,
        IRequestHandler<AlterarFuncaoCommand, bool>,
        IRequestHandler<RemoverFuncaoCommand, bool>
    {
        private readonly IFuncaoRepository _funcaoRepository;
        public FuncaoCommandHandler(IUnitOfWork uow, 
            IMediatorHandler mediatorHandler, 
            INotificationHandler<DomainNotification> domainNotification,
            IFuncaoRepository funcaoRepository) 
            : base(uow, mediatorHandler, domainNotification)
        {
            _funcaoRepository = funcaoRepository;
        }

        public async Task<bool> Handle(AlterarFuncaoCommand message, CancellationToken cancellationToken)
        {
            bool success = false;
            if (!message.EhValido())
            {
                await NotificarErrosValidacao(message);
                return success;
            }
            var funcaoDatabase = _funcaoRepository.GetById(message.Data.Id);
            if (funcaoDatabase == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, $"A função com o Id {message.Data.Id} não foi localizado!"));
                return success;
            }

            try
            {
                funcaoDatabase.AlteraDescricao(message.Data.Descricao);
                funcaoDatabase.AlteraPermissaoAutorizacaoViagem(message.Data.PermitirAutorizarViagem);
                funcaoDatabase.AlteraPermissaoCriacaoViagem(message.Data.PermitirCriarViagem);
                funcaoDatabase.AlteraLimiteOrcamentoViagem(message.Data.LimiteOrcamentoViagem);

                _funcaoRepository.Update(funcaoDatabase);
                success = await Commit();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, $"Ocorreu um erro inesperado ao Alterar Função"));
                return success;
            }
            if (success)
            {
                await _mediatorHandler.PublicarEvento(new Events.Funcao.FuncaoAlteradaEvent(funcaoDatabase));
            }
            return success;
        }

        public async Task<bool> Handle(AdicionarFuncaoCommand message, CancellationToken cancellationToken)
        {
            bool success = false;
            if (!message.EhValido())
            {
                await NotificarErrosValidacao(message);
                return success;
            }
            try
            {
                _funcaoRepository.Add(message.Data);
                success = await Commit();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, $"Ocorreu um erro inesperado ao Adicionar Função"));
                return success;
            }
            if (success)
            {
                await _mediatorHandler.PublicarEvento(new Events.Funcao.FuncaoAdicionadaEvent(message.Data));
            }
            return success;
        }

        public async Task<bool> Handle(RemoverFuncaoCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido())
            {
                await NotificarErrosValidacao(message);
                return false;
            }
            var funcaoDatabase = _funcaoRepository.GetById(message.Data.Id);
            if (funcaoDatabase == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, $"A função com o Id {message.Data.Id} não foi localizado!"));
                return false;
            }

            _funcaoRepository.Remove(message.Data.Id);
            var success = await Commit();
            if (success)
            {
                await _mediatorHandler.PublicarEvento(new Events.Funcao.FuncaoRemovidaEvent(message.Data));
            }

            return true;
        }
    }
}
