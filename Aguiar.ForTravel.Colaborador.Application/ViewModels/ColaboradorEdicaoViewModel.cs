using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Application.ViewModels
{
    public class ColaboradorEdicaoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public byte[] Foto { get; set; }
        public Guid FuncaoId { get; set; }
        public FuncaoViewModel Funcao { get; set; }
        public IList<TipoPagamentoViewModel> TiposPagamento { get; set; }
        public bool Ativo { get; set; }

        #region Dados Conta
        public string CodigoBanco { get; set; }
        public string NomeBanco { get; set; }
        public string CodigoAgencia { get; set; }
        public string DigitoAgencia { get; set; }
        public string NomeAgencia { get; set; }
        public string ContaCorrente { get; set; }
        public string DigitoContaCorrente { get; set; }
        public string FavorecidoContaCorrente { get; set; }
        #endregion
    }
}
