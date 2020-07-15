using System;
using System.Collections.Generic;
using Aguiar.ForTravel.Core.DomainObjects;

namespace Aguiar.ForTravel.Colaborador.Domain.Models
{
    public class Funcao: Entity, IAggregateRoot
    {

        protected Funcao() 
        {
            _colaboradores = new List<Colaborador>();
        }

        public Funcao(Guid id, string descricao, decimal? limiteOrcamentoViagem, bool permitirCriarViagem, bool permitirAutorizarViagem)
        {
            AlteraLimiteOrcamentoViagem(limiteOrcamentoViagem);
            AlteraPermissaoCriacaoViagem(permitirCriarViagem);
            AlteraPermissaoAutorizacaoViagem(permitirAutorizarViagem);
            AlteraDescricao(descricao);
            Id  = id;
            _colaboradores = new List<Colaborador>();
        }

        public void AlteraDescricao(string valor)
        {
            Descricao = valor;
        }

        public void AlteraPermissaoAutorizacaoViagem(bool permitir = true)
        {
            PermitirAutorizarViagem = permitir;
        }

        public void AlteraPermissaoCriacaoViagem(bool permitir = true)
        {
            PermitirCriarViagem = permitir;
        }

        public void AlteraLimiteOrcamentoViagem(decimal? valor)
        {
            LimiteOrcamentoViagem = valor;
        }

        private readonly List<Colaborador> _colaboradores;
        public IReadOnlyCollection<Colaborador> Colaboradores => _colaboradores;

        public string Descricao { get; private set; }
        public bool PermitirAutorizarViagem { get; private set; }
        public bool PermitirCriarViagem { get; private set; }
        public decimal? LimiteOrcamentoViagem { get; private set; }

    }
}
