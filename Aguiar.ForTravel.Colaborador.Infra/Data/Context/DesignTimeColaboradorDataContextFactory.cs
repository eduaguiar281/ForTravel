using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace Aguiar.ForTravel.Colaborador.Infra.Data.Context
{
    public class DesignTimeColaboradorDataContextFactory: IDesignTimeDbContextFactory<ColaboradorDataContext>
    {
        public ColaboradorDataContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<ColaboradorDataContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new ColaboradorDataContext(builder.Options);
        }


    }

    
}
