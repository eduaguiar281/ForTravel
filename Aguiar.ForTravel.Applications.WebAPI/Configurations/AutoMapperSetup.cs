using Aguiar.ForTravel.Colaborador.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using AutoMapper;

namespace Aguiar.ForTravel.Applications.WebAPI.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
        }

    }
}
