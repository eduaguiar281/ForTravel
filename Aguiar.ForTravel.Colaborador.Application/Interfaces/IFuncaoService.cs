using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aguiar.ForTravel.Colaborador.Application.ViewModels;

namespace Aguiar.ForTravel.Colaborador.Application.Interfaces
{
    public interface IFuncaoService: IDisposable
    {
        Task Adicionar(FuncaoViewModel funcaoViewModel);
        Task Alterar(FuncaoViewModel funcaoViewModel);
        Task Remover(Guid id);
        IEnumerable<FuncaoViewModel> ObterTodos();
        FuncaoViewModel ObterPorId(Guid id);
    }
}