using Aguiar.ForTravel.Colaborador.Application.Configurations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Aguiar.ForTravel.Applications.WebAPI.Configurations
{
    public static class RegistrarDependencias
    {
        public static void RegistrarServicos(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.RegisterServices();
        }

    }
}
