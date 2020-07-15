using Aguiar.ForTravel.Colaborador.Application.ViewModels;
using Aguiar.ForTravel.Colaborador.Domain.Models;
using AutoMapper;

namespace Aguiar.ForTravel.Colaborador.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Funcao, FuncaoViewModel>();
            CreateMap<TipoPagamento, TipoPagamentoViewModel>();
            CreateMap<Domain.Models.Colaborador, ColaboradorItemListaViewModel>();
        }

    }
}
