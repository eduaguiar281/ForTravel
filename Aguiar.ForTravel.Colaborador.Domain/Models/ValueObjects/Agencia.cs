using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Domain.Models.ValueObjects
{
    public class Agencia
    {
        protected Agencia() { }
        public Agencia(string codigo, string digito, string nome)
        {
            Codigo = codigo;
            Digito = digito;
            Nome = nome;
        }
        public string Codigo { get; private set; }
        public string Digito { get; private set; }
        public string Nome { get; private set; }

    }
}
