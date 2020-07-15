using Aguiar.ForTravel.Colaborador.Domain.Models.ValueObjects;
using Aguiar.ForTravel.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aguiar.ForTravel.Colaborador.Domain.Models
{

    /// <summary>
    /// Classe Colaborador Raiz de Agregação
    /// </summary>
    public class Colaborador: Entity, IAggregateRoot, ICopiavel<Colaborador>
    {
        /// <summary>
        /// ATENÇÃO: Ao alterar a classe e incluir propriedade alterar o método Clone
        /// </summary>

        protected Colaborador()
        {
            _tiposPagamento = new List<TiposPagamentoColaborador>();
        }

        public Colaborador(Guid id,
            string nome,
            string apelido,
            byte[] foto,
            string usuarioId,
            string email, 
            Funcao funcao, 
            DadosConta dadosConta = null, 
            IEnumerable<TiposPagamentoColaborador> tipoPagamentos = null)
        {
            Id = id;
            AlterarNome(nome);
            AlterarApelido(apelido);
            AlterarFoto(foto);
            AlterarUsuarioId(usuarioId);
            AlterarEmail(email);
            AtribuirFuncao(funcao);
            AlterarDadosConta(dadosConta);
            AtivarColaborador();
            _tiposPagamento = new List<TiposPagamentoColaborador>();
            if(tipoPagamentos != null)
            {
                foreach (var tipo in tipoPagamentos)
                    AtribuirTipoPagamento(tipo);
            }
        }
        
        public string Nome { get; private set; }
        public void AlterarNome (string valor)
        {
            Nome = valor;
        }

        public string Apelido { get; private set; }
        public void AlterarApelido(string valor)
        {
            Apelido = valor;
        }

        public byte[] Foto { get; private set; }
        public void AlterarFoto(byte[] foto)
        {
            Foto = foto;
        }

        public string UsuarioId { get; private set; }
        public void AlterarUsuarioId(string valor)
        {
            UsuarioId = valor;
        }

        public string Email { get; private set; }
        public void AlterarEmail(string valor)
        {
            Email = valor;
        }

        public virtual Funcao Funcao { get; private set; }
        public Guid? FuncaoId { get; private set; }
        public void AtribuirFuncao(Funcao funcao)
        {
            Funcao = funcao;
            FuncaoId = funcao != null ? funcao.Id : default;
        }

        public DadosConta DadosConta { get; private set; }
        public void AlterarDadosConta(DadosConta dadosConta)
        {
            DadosConta = dadosConta;
        }
        public void LimparDadosConta()
        {
            DadosConta = null;
        }

        private readonly List<TiposPagamentoColaborador> _tiposPagamento;
        public IReadOnlyCollection<TiposPagamentoColaborador> TiposPagamento => _tiposPagamento;

        public bool Ativo { get; private set; }

        public void AtivarColaborador()
        {
            Ativo = true;
        }

        public void DesativarColaborador()
        {
            Ativo = false;
        }

        public void AtribuirTipoPagamento(TiposPagamentoColaborador tipoPagamento)
        {
            if (tipoPagamento == null)
                throw new ArgumentNullException(nameof(tipoPagamento));
            
            if (tipoPagamento.ColaboradorId != Id)
                throw new DomainException($"Tipo de pagamento {tipoPagamento.TipoPagamento?.Descricao} não está vinculado ao colaborador {Nome}.");

            if (ExisteTipoPagamento(tipoPagamento.Id))
                throw new DomainException($"Tipo de pagamento {tipoPagamento.TipoPagamento?.Descricao} já foi atribuído ao colaborador {Nome}.");
            _tiposPagamento.Add(tipoPagamento);

        }

        private bool ExisteTipoPagamento(Guid id)
        {
            return _tiposPagamento.FirstOrDefault(t => t.Id == id) != null;
        }

        public void RemoverTipoPagamento(TiposPagamentoColaborador tipoPagamento)
        {
            if (tipoPagamento == null)
                throw new ArgumentNullException(nameof(tipoPagamento));
            if (!ExisteTipoPagamento(tipoPagamento.Id))
                throw new DomainException($"Tipo de pagamento {tipoPagamento.TipoPagamento?.Descricao} não está atribuído ao colaborador {Nome}.");
            var tipoPagamentoDB = _tiposPagamento.FirstOrDefault(t => t.Id == tipoPagamento.Id);
            _tiposPagamento.Remove(tipoPagamentoDB);
        }

        private void LimparListaTipoPagamento()
        {
            _tiposPagamento.Clear();
        }

        public static class ColaboradorFactory
        {
            public static Colaborador NovoColaborador()
            {
                return new Colaborador();
            }
        }

        public void Copiar(Colaborador origem)
        {
            AlterarNome(origem.Nome);
            AlterarApelido(origem.Apelido);
            AlterarFoto(origem.Foto);
            AlterarUsuarioId(origem.UsuarioId);
            AlterarEmail(origem.Email);
            AtribuirFuncao(origem.Funcao);
            AlterarDadosConta(origem.DadosConta);
            if (origem.Ativo)
                AtivarColaborador();
            else
                DesativarColaborador();

            if (origem.TiposPagamento != null)
            {
                LimparListaTipoPagamento();
                foreach (var tipo in origem.TiposPagamento)
                    AtribuirTipoPagamento(tipo);
            }
        }

    }

}
