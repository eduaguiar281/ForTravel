using System;
using System.Collections.Generic;
using System.Text;
using Aguiar.ForTravel.Colaborador.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aguiar.ForTravel.Colaborador.Infra.Data.Mappings
{
    public class FuncaoMap : IEntityTypeConfiguration<Funcao>
    {
        public void Configure(EntityTypeBuilder<Funcao> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Descricao).IsRequired();
            builder.ToTable(nameof(Funcao));
        }
    }
}
