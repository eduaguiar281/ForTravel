using Aguiar.ForTravel.Colaborador.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aguiar.ForTravel.Colaborador.Application.Interfaces
{
    public interface IColaboradorService
    {
        ListaColaboradorViewModel ObterListaColaborador();
        ColaboradorEdicaoViewModel ObterColaboradorPorId(Guid Id);
        Task AdicionarColaborador(ColaboradorEdicaoViewModel viewModel);
        Task AlterarColaborador(ColaboradorEdicaoViewModel viewModel);
        Task AtribuirFuncaoAoColaborador(Guid id, FuncaoViewModel funcao);
        Task AtivarColaborador(Guid id);
        Task DesativarColaborador(Guid id);
        Task AtribuirTipoPagamentoAoColaborador(Guid id, TipoPagamentoViewModel tipoPagamento);
        Task RemoverTipoPagamentoDoColaborador(Guid id, TipoPagamentoViewModel tipoPagamento);
        Task AtribuirTipoPagamentoAoColaborador(Guid id, IEnumerable<TipoPagamentoViewModel> tiposPagamento);
        Task RemoverTipoPagamentoDoColaborador(Guid id, IEnumerable<TipoPagamentoViewModel> tiposPagamento);
        IList<TipoPagamentoViewModel> ObterTipoPagamentoColaborador(Guid id);
    }
}
