using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Application.ViewModels
{
    public class ColaboradorItemListaViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public string NomeFuncao { get; set; }
        public bool Ativo { get; set; }
    }
}
