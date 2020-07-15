using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aguiar.ForTravel.Colaborador.Application.ViewModels;
using Aguiar.ForTravel.Colaborador.Domain.Command.Colaborador;
using Aguiar.ForTravel.Colaborador.Domain.Command.Funcao;
using Aguiar.ForTravel.Colaborador.Domain.Command.TipoPagamento;
using Aguiar.ForTravel.Colaborador.Domain.Models;
using Aguiar.ForTravel.Colaborador.Domain.Models.ValueObjects;
using AutoMapper;

namespace Aguiar.ForTravel.Colaborador.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            /*Função*/
            CreateMap<FuncaoViewModel, AdicionarFuncaoCommand>()
                .ConstructUsing(f => new AdicionarFuncaoCommand(new Funcao(Guid.NewGuid(), f.Descricao,
                    f.LimiteOrcamentoViagem, f.PermitirCriarViagem, f.PermitirAutorizarViagem)));
            CreateMap<FuncaoViewModel, AlterarFuncaoCommand>()
                .ConstructUsing(f => new AlterarFuncaoCommand(new Funcao(f.Id, f.Descricao,
                    f.LimiteOrcamentoViagem, f.PermitirCriarViagem, f.PermitirAutorizarViagem)));
            CreateMap<FuncaoViewModel, RemoverFuncaoCommand>()
                .ConstructUsing(f => new RemoverFuncaoCommand(new Funcao(f.Id, f.Descricao,
                    f.LimiteOrcamentoViagem, f.PermitirCriarViagem, f.PermitirAutorizarViagem)));
            CreateMap<FuncaoViewModel, Funcao>()
                .ConstructUsing(f => new Funcao(f.Id, f.Descricao,
                    f.LimiteOrcamentoViagem, f.PermitirCriarViagem, f.PermitirAutorizarViagem));

            /*Tipo Pagamento*/
            CreateMap<TipoPagamentoViewModel, AdicionarTipoPagamentoCommand>()
                .ConstructUsing(f => new AdicionarTipoPagamentoCommand(new TipoPagamento(Guid.NewGuid(), f.Descricao,
                    f.RequerDadosCartao, f.EhCartaoCorporativo, f.RequerDadosConta)));
            CreateMap<TipoPagamentoViewModel, AlterarTipoPagamentoCommand>()
                .ConstructUsing(f => new AlterarTipoPagamentoCommand(new TipoPagamento(f.Id, f.Descricao,
                    f.RequerDadosCartao, f.EhCartaoCorporativo, f.RequerDadosConta)));
            CreateMap<TipoPagamentoViewModel, RemoverTipoPagamentoCommand>()
                .ConstructUsing(f => new RemoverTipoPagamentoCommand(new TipoPagamento(f.Id, f.Descricao,
                    f.RequerDadosCartao, f.EhCartaoCorporativo, f.RequerDadosConta)));
            CreateMap<TipoPagamentoViewModel, TipoPagamento>()
                .ConstructUsing(t => new TipoPagamento(t.Id, t.Descricao, t.RequerDadosCartao, t.EhCartaoCorporativo, t.RequerDadosConta));
            
            /*Colaborador*/
            CreateMap<ColaboradorEdicaoViewModel, AdicionarColaboradorCommand>()
                .ConstructUsing(c => new AdicionarColaboradorCommand(new Domain.Models.Colaborador(Guid.NewGuid(),
                c.Nome,
                c.Apelido,
                c.Foto,
                Guid.Empty.ToString(),
                c.Email,
                null,
                new DadosConta(new Banco(c.CodigoBanco, c.NomeBanco), 
                               new Agencia(c.CodigoAgencia, c.DigitoAgencia, c.NomeAgencia), 
                               c.ContaCorrente, 
                               c.DigitoContaCorrente, 
                               c.FavorecidoContaCorrente),
                null
                ), 
                c.FuncaoId,
                c.TiposPagamento.Select(t => t.Id).ToList()));
            CreateMap<ColaboradorEdicaoViewModel, AlterarColaboradorCommand>()
                .ConstructUsing(c => new AlterarColaboradorCommand(new Domain.Models.Colaborador(c.Id,
                c.Nome,
                c.Apelido,
                c.Foto,
                Guid.Empty.ToString(),
                c.Email,
                new Funcao(c.Funcao.Id,
                           c.Funcao.Descricao,
                           c.Funcao.LimiteOrcamentoViagem,
                           c.Funcao.PermitirCriarViagem,
                           c.Funcao.PermitirAutorizarViagem),
                new DadosConta(new Banco(c.CodigoBanco, c.NomeBanco),
                               new Agencia(c.CodigoAgencia, c.DigitoAgencia, c.NomeAgencia),
                               c.ContaCorrente,
                               c.DigitoContaCorrente,
                               c.FavorecidoContaCorrente),
                c.TiposPagamento.Select(t => new TipoPagamento(t.Id, t.Descricao, t.RequerDadosCartao, t.EhCartaoCorporativo, t.RequerDadosConta)).ToList()
                )));

        }
    }
}
