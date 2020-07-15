using Aguiar.ForTravel.Colaborador.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aguiar.ForTravel.Colaborador.Application.Interfaces
{
    public interface ITipoPagamentoService
    {
        Task Adicionar(TipoPagamentoViewModel viewModel);
        Task Alterar(TipoPagamentoViewModel viewModel);
        Task Remover(Guid id);
        IEnumerable<TipoPagamentoViewModel> ObterTodos();
        TipoPagamentoViewModel ObterPorId(Guid id);

    }
}
