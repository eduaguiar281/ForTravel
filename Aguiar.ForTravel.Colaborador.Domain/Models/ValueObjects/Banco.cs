using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Domain.Models.ValueObjects
{
    public class Banco
    {
        protected Banco() { }
        public Banco(string codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }
        public string Codigo { get; private set; }
        public string Nome { get; private set; }

    }
}
