using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Application.ViewModels
{
    public class ListaColaboradorViewModel
    {
        public ListaColaboradorViewModel() { Lista = new List<ColaboradorItemListaViewModel>(); }

        public IList<ColaboradorItemListaViewModel> Lista { get; set; }
    }
}
