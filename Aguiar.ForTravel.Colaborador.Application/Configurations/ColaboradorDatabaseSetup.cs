using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Aguiar.ForTravel.Colaborador.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Aguiar.ForTravel.Colaborador.Application.Configurations
{
    public static class ColaboradorDatabaseSetup
    {
        public static void AddColaboradorDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<ColaboradorDataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

    }
}
