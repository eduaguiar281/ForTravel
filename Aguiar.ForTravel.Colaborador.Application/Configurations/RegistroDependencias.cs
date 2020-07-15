using Aguiar.ForTravel.Colaborador.Application.Interfaces;
using Aguiar.ForTravel.Colaborador.Application.Services;
using Aguiar.ForTravel.Colaborador.Domain.Command.Colaborador;
using Aguiar.ForTravel.Colaborador.Domain.Command.Funcao;
using Aguiar.ForTravel.Colaborador.Domain.Command.TipoPagamento;
using Aguiar.ForTravel.Colaborador.Domain.CommandHandlers;
using Aguiar.ForTravel.Colaborador.Domain.EventHandlers;
using Aguiar.ForTravel.Colaborador.Domain.Events.Colaborador;
using Aguiar.ForTravel.Colaborador.Domain.Events.Funcao;
using Aguiar.ForTravel.Colaborador.Domain.Events.TipoPagamento;
using Aguiar.ForTravel.Colaborador.Domain.Interfaces;
using Aguiar.ForTravel.Colaborador.Infra.Data.Context;
using Aguiar.ForTravel.Colaborador.Infra.Data.Repository;
using Aguiar.ForTravel.Core.Communication.Mediator;
using Aguiar.ForTravel.Core.Data;
using Aguiar.ForTravel.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace Aguiar.ForTravel.Colaborador.Application.Configurations
{
    public static class RegistroDependencias
    {

        public static void RegisterServices(this IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, MediatorHandler>();


            #region Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            #region Funcao
            services.AddScoped<INotificationHandler<FuncaoAdicionadaEvent>, FuncaoEventHandler>();
            services.AddScoped<INotificationHandler<FuncaoAlteradaEvent>, FuncaoEventHandler>();
            services.AddScoped<INotificationHandler<FuncaoRemovidaEvent>, FuncaoEventHandler>();
            #endregion

            #region TipoPagamento
            services.AddScoped<INotificationHandler<TipoPagamentoAdicionadoEvent>, TipoPagamentoEventHandler>();
            services.AddScoped<INotificationHandler<TipoPagamentoAlteradoEvent>, TipoPagamentoEventHandler>();
            services.AddScoped<INotificationHandler<TipoPagamentoRemovidoEvent>, TipoPagamentoEventHandler>();
            #endregion

            #region Colaborador
            services.AddScoped<INotificationHandler<ColaboradorAdicionadoEvent>, ColaboradorEventHandler>();
            services.AddScoped<INotificationHandler<ColaboradorAlteradoEvent>, ColaboradorEventHandler>();
            services.AddScoped<INotificationHandler<ColaboradorAtivadoEvent>, ColaboradorEventHandler>();
            services.AddScoped<INotificationHandler<ColaboradorDesativadoEvent>, ColaboradorEventHandler>();
            services.AddScoped<INotificationHandler<ColaboradorFuncaoAtribuidaEvent>, ColaboradorEventHandler>();
            services.AddScoped<INotificationHandler<ColaboradorTipoPagamentoAtribuidoEvent>, ColaboradorEventHandler>();
            services.AddScoped<INotificationHandler<ColaboradorTipoPagamentoRemovidoEvent>, ColaboradorEventHandler>();
            #endregion

            #endregion

            #region Domain - Commands

            #region Funcao
            services.AddScoped<IRequestHandler<AdicionarFuncaoCommand, bool>, FuncaoCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarFuncaoCommand, bool>, FuncaoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverFuncaoCommand, bool>, FuncaoCommandHandler>();
            #endregion

            #region TipoPagamento
            services.AddScoped<IRequestHandler<AdicionarTipoPagamentoCommand, bool>, TipoPagamentoCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarTipoPagamentoCommand, bool>, TipoPagamentoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverTipoPagamentoCommand, bool>, TipoPagamentoCommandHandler>();
            #endregion

            #region Colaborador
            services.AddScoped<IRequestHandler<AdicionarColaboradorCommand, bool>, ColaboradorCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarColaboradorCommand, bool>, ColaboradorCommandHandler>();
            services.AddScoped<IRequestHandler<AtivarColaboradorCommand, bool>, ColaboradorCommandHandler>();
            services.AddScoped<IRequestHandler<DesativarColaboradorCommand, bool>, ColaboradorCommandHandler>();
            services.AddScoped<IRequestHandler<AtribuirFuncaoColaboradorCommand, bool>, ColaboradorCommandHandler>();
            services.AddScoped<IRequestHandler<AtribuirTipoPagamentoColaboradorCommand, bool>, ColaboradorCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverTipoPagamentoColaboradorCommand, bool>, ColaboradorCommandHandler>();
            #endregion

            #endregion

            #region Infra - Data
            services.AddScoped<IFuncaoRepository, FuncaoRepository>();
            services.AddScoped<ITipoPagamentoRepository, TipoPagamentoRepository>();
            services.AddScoped<IDataContext, ColaboradorDataContext>();
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            // Application
            services.AddScoped<IFuncaoService, FuncaoService>();
            services.AddScoped<ITipoPagamentoService, TipoPagamentoService>();
            services.AddScoped<IColaboradorService, ColaboradorService>();
        }

    }
}
