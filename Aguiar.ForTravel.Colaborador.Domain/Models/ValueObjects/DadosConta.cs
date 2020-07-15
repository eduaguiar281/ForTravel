using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Domain.Models.ValueObjects
{
    public class DadosConta
    {
        protected DadosConta() { }
        public DadosConta(Banco banco, Agencia agencia, string conta, string digito, string favorecido)
        {
            Banco = banco;
            Agencia = agencia;
            Conta = conta;
            Digito = digito;
            Favorecido = favorecido;
        }

        public Banco Banco { get; private set; }
        public Agencia Agencia { get; private set; }
        public string Conta { get; private set; }
        public string Digito { get; private set; }
        public string Favorecido { get; private set; }
    }

}
