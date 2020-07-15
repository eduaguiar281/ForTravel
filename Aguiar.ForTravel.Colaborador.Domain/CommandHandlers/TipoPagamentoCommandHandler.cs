using Aguiar.ForTravel.Colaborador.Domain.Command.TipoPagamento;
using Aguiar.ForTravel.Colaborador.Domain.Interfaces;
using Aguiar.ForTravel.Core.Communication.Mediator;
using Aguiar.ForTravel.Core.Data;
using Aguiar.ForTravel.Core.Messages;
using Aguiar.ForTravel.Core.Messages.CommonMessages.Notifications;
using MediatR;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Aguiar.ForTravel.Colaborador.Domain.CommandHandlers
{
    public class TipoPagamentoCommandHandler : CommandHandler,
        IRequestHandler<AdicionarTipoPagamentoCommand, bool>,
        IRequestHandler<AlterarTipoPagamentoCommand, bool>,
        IRequestHandler<RemoverTipoPagamentoCommand, bool>

    {
        private readonly ITipoPagamentoRepository _tipoPagamentoRepository;

        public TipoPagamentoCommandHandler(IUnitOfWork uow,
            IMediatorHandler mediatorHandler,
            INotificationHandler<DomainNotification> domainNotification,
            ITipoPagamentoRepository tipoPagamentoRepository)
            : base(uow, mediatorHandler, domainNotification)
        {
            _tipoPagamentoRepository = tipoPagamentoRepository;
        }


        public async Task<bool> Handle(AdicionarTipoPagamentoCommand message, CancellationToken cancellationToken)
        {
            bool success = false;
            if (!message.EhValido())
            {
                await NotificarErrosValidacao(message);
                return success;
            }
            try
            {
                _tipoPagamentoRepository.Add(message.Data);
                success = await Commit();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, $"Ocorreu um erro inesperado ao Adicionar Tipo Pagamento"));
                return success;
            }
            if (success)
            {
                await _mediatorHandler.PublicarEvento(new Events.TipoPagamento.TipoPagamentoAdicionadoEvent(message.Data));
            }
            return success;
        }

        public async Task<bool> Handle(AlterarTipoPagamentoCommand message, CancellationToken cancellationToken)
        {
            bool success = false;
            if (!message.EhValido())
            {
                await NotificarErrosValidacao(message);
                return success;
            }
            var tipoPagamentoDatabase = _tipoPagamentoRepository.GetById(message.Data.Id);
            if (tipoPagamentoDatabase == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, $"O tipo de pagamento com o Id {message.Data.Id} não foi localizado!"));
                return success;
            }
            try
            {
                tipoPagamentoDatabase.AlteraDescricao(message.Data.Descricao);
                tipoPagamentoDatabase.AlteraRequerDadosCartao(message.Data.RequerDadosCartao);
                tipoPagamentoDatabase.AlteraEhCartaoCorporativo(message.Data.EhCartaoCorporativo);
                tipoPagamentoDatabase.AlteraRequerDadosConta(message.Data.RequerDadosConta);

                _tipoPagamentoRepository.Update(tipoPagamentoDatabase);
                success = await Commit();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, $"Ocorreu um erro inesperado ao Alterar Tipo Pagamento"));
                return success;
            }
            if (success)
            {
                await _mediatorHandler.PublicarEvento(new Events.TipoPagamento.TipoPagamentoAlteradoEvent(message.Data));
            }
            return success;
        }

        public async Task<bool> Handle(RemoverTipoPagamentoCommand message, CancellationToken cancellationToken)
        {

            bool success = false;
            if (!message.EhValido())
            {
                await NotificarErrosValidacao(message);
                return success;
            }
            var tipoPagamentoDatabase = _tipoPagamentoRepository.GetById(message.Data.Id);
            if (tipoPagamentoDatabase == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, $"O tipo de pagamento com o Id {message.Data.Id} não foi localizado!"));
                return success;
            }

            try
            {
                _tipoPagamentoRepository.Remove(tipoPagamentoDatabase.Id);
                success = await Commit();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, $"Ocorreu um erro inesperado ao Remover Tipo Pagamento"));
                return success;
            }
            if (success)
            {
                await _mediatorHandler.PublicarEvento(new Events.TipoPagamento.TipoPagamentoRemovidoEvent(message.Data));
            }
            return success;
        }
    }
}
