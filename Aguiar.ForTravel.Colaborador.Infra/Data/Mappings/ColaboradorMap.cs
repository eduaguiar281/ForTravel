using Aguiar.ForTravel.Colaborador.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Infra.Data.Mappings
{
    public class ColaboradorMap : IEntityTypeConfiguration<Domain.Models.Colaborador>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Colaborador> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.FuncaoId).IsRequired();
            builder.OwnsOne(c => c.DadosConta, dc =>
            {
                dc.OwnsOne(b => b.Banco).Property(p => p.Codigo).HasColumnName("CodigoBanco").HasColumnType("varchar(3)");
                dc.OwnsOne(b => b.Banco).Property(p => p.Nome).HasColumnName("NomeBanco").HasColumnType("varchar(100)");
                dc.OwnsOne(b => b.Agencia).Property(p => p.Codigo).HasColumnName("CodigoAgencia").HasColumnType("varchar(10)");
                dc.OwnsOne(b => b.Agencia).Property(p => p.Digito).HasColumnName("DigitoAgencia").HasColumnType("varchar(5)");
                dc.OwnsOne(b => b.Agencia).Property(p => p.Nome).HasColumnName("NomeAgencia").HasColumnType("varchar(100)");
                dc.Property(d => d.Conta).HasColumnName("ContaCorrente").HasColumnType("varchar(50)");
                dc.Property(d => d.Digito).HasColumnName("DigitoConta").HasColumnType("varchar(5)");
            });


        }
    }
}
