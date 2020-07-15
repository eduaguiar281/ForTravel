using Aguiar.ForTravel.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Domain.Models
{
    public class TipoPagamento: Entity, IAggregateRoot
    {

        protected TipoPagamento()
        {
            _tiposPagamentoColaborador = new List<TiposPagamentoColaborador>();
        }

        public TipoPagamento(Guid id, string descricao, bool requerDadosCartao, bool ehCartaoCorporativo, bool requerDadosConta)
        {
            Id = id;
            AlteraDescricao(descricao);
            AlteraRequerDadosCartao(requerDadosCartao);
            AlteraEhCartaoCorporativo(ehCartaoCorporativo);
            AlteraRequerDadosConta(requerDadosConta);
            _tiposPagamentoColaborador = new List<TiposPagamentoColaborador>();
        }

        public IReadOnlyCollection<TiposPagamentoColaborador> TiposPagamentoColaborador => _tiposPagamentoColaborador;
        private readonly List<TiposPagamentoColaborador> _tiposPagamentoColaborador;

        public string Descricao { get; private set; }
        public void AlteraDescricao(string valor)
        {
            Descricao = valor;
        }

        public bool RequerDadosCartao { get; private set; }
        public void AlteraRequerDadosCartao(bool valor)
        {
            RequerDadosCartao = valor;
            if (!valor)
                EhCartaoCorporativo = false;
        }

        public bool EhCartaoCorporativo { get; private set; }
        public void AlteraEhCartaoCorporativo(bool valor)
        {
            EhCartaoCorporativo = valor;
            if (valor)
                RequerDadosCartao = true;
        }

        public bool RequerDadosConta { get; private set; }
        public void AlteraRequerDadosConta(bool valor)
        {
            RequerDadosConta = valor;
        }
    }
}
