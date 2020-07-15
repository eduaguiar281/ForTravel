using Aguiar.ForTravel.Colaborador.Domain.Command.Colaborador;
using Aguiar.ForTravel.Colaborador.Domain.Interfaces;
using Aguiar.ForTravel.Colaborador.Domain.Models;
using Aguiar.ForTravel.Core.Communication.Mediator;
using Aguiar.ForTravel.Core.Data;
using Aguiar.ForTravel.Core.Messages;
using Aguiar.ForTravel.Core.Messages.CommonMessages.DomainCommands;
using Aguiar.ForTravel.Core.Messages.CommonMessages.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aguiar.ForTravel.Core.Extensions;
using Aguiar.ForTravel.Core.DomainObjects;

namespace Aguiar.ForTravel.Colaborador.Domain.CommandHandlers
{
    public class ColaboradorCommandHandler : CommandHandler,
        IRequestHandler<AdicionarColaboradorCommand, bool>,
        IRequestHandler<AlterarColaboradorCommand, bool>,
        IRequestHandler<DesativarColaboradorCommand, bool>,
        IRequestHandler<AtribuirFuncaoColaboradorCommand, bool>,
        IRequestHandler<AtivarColaboradorCommand, bool>,
        IRequestHandler<AtribuirTipoPagamentoColaboradorCommand, bool>,
        IRequestHandler<RemoverTipoPagamentoColaboradorCommand, bool>
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IFuncaoRepository _funcaoRepository;
        private readonly ITipoPagamentoRepository _tipoPagamentoRepository;
        #region Ctor

        public ColaboradorCommandHandler(IUnitOfWork uow,
            IMediatorHandler mediatorHandler,
            INotificationHandler<DomainNotification> domainNotification,
            IColaboradorRepository colaboradorRepository,
            IFuncaoRepository funcaoRepository,
            ITipoPagamentoRepository tipoPagamentoRepository)
            :base(uow, mediatorHandler, domainNotification)
        {
            _colaboradorRepository = colaboradorRepository;
            _funcaoRepository = funcaoRepository;
            _tipoPagamentoRepository = tipoPagamentoRepository;
        }

        #endregion


        #region CRUD Commands
        public async Task<bool> Handle(AlterarColaboradorCommand message, CancellationToken cancellationToken)
        {
            var success = await Validar(message);
            if (!success)
                return success;
            var colaboradorDb = ObterColaboradorPorId(message, ref success);
            if (success)
            {
                colaboradorDb.Copiar(message.Data);
                success = await AlterarColaborador(colaboradorDb, message.MessageType);
                if (success)
                    await _mediatorHandler.PublicarEvento(new Events.Colaborador.ColaboradorAlteradoEvent(colaboradorDb));
            }
            return success;
        }

        public async Task<bool> Handle(AdicionarColaboradorCommand message, CancellationToken cancellationToken)
        {
            var success = await Validar(message) && await AdicionarColaboradorCommandEhConsistente(message);
            if (!success)
                return success;
            try
            {
                if (message.FuncaoId.HasValue)
                {
                    var funcao = _funcaoRepository.GetById(message.FuncaoId.Value);
                    message.Data.AtribuirFuncao(funcao);
                }
                foreach(var id in message.TipoPagamentoIds)
                {
                    var tipoPagamento = _tipoPagamentoRepository.GetById(id);
                    var tipoPagamentoColaborador = new TiposPagamentoColaborador(tipoPagamento, message.Data);
                    message.Data.AtribuirTipoPagamento(tipoPagamentoColaborador);
                }
                _colaboradorRepository.Add(message.Data);
                await _colaboradorRepository.UnitOfWork.Commit();
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
                Debug.WriteLine(ex.Message);
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, $"Ocorreu um erro inesperado ao Adicionar Colaborador"));
                return success;
            }
            if (success)
            {
                await _mediatorHandler.PublicarEvento(new Events.Colaborador.ColaboradorAdicionadoEvent(message.Data));
            }
            return success;
        }
        private async Task<bool> AdicionarColaboradorCommandEhConsistente(AdicionarColaboradorCommand message)
        {
            var success = true;
            if (message.FuncaoId.HasValue)
            {
                if (!_colaboradorRepository.FuncaoExiste(message.FuncaoId.Value))
                {
                    await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, $"A função informada {message.FuncaoId} não foi localizada no banco de dados!"));
                    success = false;
                }
            }
            if (message.TipoPagamentoIds != null)
            {
                foreach(var tipo in message.TipoPagamentoIds)
                {
                    if (!_colaboradorRepository.TipoPagamentoExiste(tipo))
                    {
                        await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, $"O tipo de pagamento informado {tipo} não foi localizado no banco de dados!"));
                        success = false;
                    }
                }
            }
            return success;

        }

        #endregion

        public async Task<bool> Handle(AtribuirFuncaoColaboradorCommand message, CancellationToken cancellationToken)
        {
            var success = await Validar(message);
            if (!success)
                return success;
            if (!_colaboradorRepository.FuncaoExiste(message.NovaFuncao.Id))
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, $"A função informada {message.NovaFuncao.Id}- {message.NovaFuncao.Descricao} não foi localizada no banco de dados!"));
                return success;
            }
            else
            {
                var colaboradorDb = ObterColaboradorPorId(message, ref success);
                if (success)
                {
                    colaboradorDb.AtribuirFuncao(message.NovaFuncao);
                    success = await AlterarColaborador(colaboradorDb, message.MessageType);
                    if (success)
                        await _mediatorHandler.PublicarEvento(new Events.Colaborador.ColaboradorFuncaoAtribuidaEvent(colaboradorDb));
                }
            }
            return success;
        }

        public async Task<bool> Handle(AtribuirTipoPagamentoColaboradorCommand message, CancellationToken cancellationToken)
        {
            var success = await Validar(message);
            if (!success)
                return success;
            var colaboradorDb = ObterColaboradorPorId(message, ref success);
            if (success)
            {
                if (await TipoPagamentoExiste(message.TiposPagamentoAdicionar, message))
                {
                    try
                    {
                        message.TiposPagamentoAdicionar.ForEach(item => { colaboradorDb.AtribuirTipoPagamento(item); });
                        _colaboradorRepository.AdicionarTiposPagamentos(colaboradorDb);
                        if (await AlterarColaborador(colaboradorDb, message.MessageType))
                        {
                            await _mediatorHandler.PublicarEvento(new Events.Colaborador.ColaboradorTipoPagamentoAtribuidoEvent(colaboradorDb));
                            success = true;
                        }
                    }
                    catch (DomainException ex)
                    {
                        await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, ex.Message));
                        success = false;
                    }
                }
            }
            return success;
        }

        public async Task<bool> Handle(RemoverTipoPagamentoColaboradorCommand message, CancellationToken cancellationToken)
        {
            var success = await Validar(message);
            if (!success)
                return success;
            var colaboradorDb = ObterColaboradorPorId(message, ref success);
            if (success)
            {
                if (await TipoPagamentoExiste(message.TiposPagamentoRemover, message))
                {
                    try
                    {
                        message.TiposPagamentoRemover.ForEach(item => { colaboradorDb.RemoverTipoPagamento(item); });
                        if (await AlterarColaborador(colaboradorDb, message.MessageType))
                        {
                            await _mediatorHandler.PublicarEvento(new Events.Colaborador.ColaboradorTipoPagamentoRemovidoEvent(colaboradorDb));
                        }
                        else
                            success = false;
                    }
                    catch (DomainException ex)
                    {
                        await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, ex.Message));
                        success = false;
                    }
                }
            }
            return success;
        }


        #region Ativar/Desativar Commnads
        public async Task<bool> Handle(AtivarColaboradorCommand message, CancellationToken cancellationToken)
        {
            var success = await Validar(message);
            if (!success)
                return success;
            var colaboradorDb = ObterColaboradorPorId(message, ref success);
            if (success)
            {
                if (colaboradorDb.Ativo)
                {
                    await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, $"O colaborador informado {message.Data.Id}- {message.Data.Nome} já está ativado!"));
                    return success;
                }
                colaboradorDb.AtivarColaborador();
                success = await AlterarColaborador(colaboradorDb, message.MessageType);
                if (success)
                    await _mediatorHandler.PublicarEvento(new Events.Colaborador.ColaboradorAtivadoEvent(colaboradorDb));
            }
            return success;
        }
        public async Task<bool> Handle(DesativarColaboradorCommand message, CancellationToken cancellationToken)
        {
            var success = await Validar(message);
            if (!success)
                return success;
            var colaboradorDb = ObterColaboradorPorId(message, ref success);
            if (success)
            {
                if (!colaboradorDb.Ativo)
                {
                    await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, $"O colaborador informado {message.Data.Id}- {message.Data.Nome} já foi desativado!"));
                    return success;
                }
                colaboradorDb.DesativarColaborador();
                success = await AlterarColaborador(colaboradorDb, message.MessageType);
                if (success)
                    await _mediatorHandler.PublicarEvento(new Events.Colaborador.ColaboradorDesativadoEvent(colaboradorDb));
            }
            return success;
        }
        #endregion


        #region Métodos Privados
        private Models.Colaborador ObterColaboradorPorId(DomainCommand<Models.Colaborador> message, ref bool success)
        {
            var colaboradorDb = _colaboradorRepository.GetById(message.Data.Id);
            if (colaboradorDb == null)
            {
                _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, $"Colaborador id:{message.Data.Id}- {message.Data.Nome} não foi localizado no banco de dados!")).Wait();
                success = false;
            }
            return colaboradorDb;
        }

        private async Task<bool> AlterarColaborador(Models.Colaborador colaboradorDb, string messageType)
        {
            try
            {
                _colaboradorRepository.Update(colaboradorDb);
                await _colaboradorRepository.UnitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(messageType, $"Ocorreu um erro inesperado ao Alterar Colaborador"));
                return false;
            }

        }
        
        private async Task<bool> TipoPagamentoExiste(IList<TipoPagamento> lista, DomainCommand<Models.Colaborador> message)
        {
            var result = new StringBuilder();
            foreach(var item in lista)
            {
                if (!_colaboradorRepository.TipoPagamentoExiste(item.Id))
                    result.AppendLine($"Tipo de Pagamento {item.Id}- {item.Descricao} não foi encontrado no banco de dados!");
            }
            if (result.Length > 0)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, result.ToString()));
                return false;
            }
            return true;
        }


        private async Task<bool> Validar(DomainCommand<Models.Colaborador> message)
        {
            if (!message.EhValido())
            {
                await NotificarErrosValidacao(message);
                return false;
            }
            return true;
        }

        #endregion
    }
}
