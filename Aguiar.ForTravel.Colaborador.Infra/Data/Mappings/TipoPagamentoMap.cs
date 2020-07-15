using Aguiar.ForTravel.Colaborador.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Infra.Data.Mappings
{
    public class TipoPagamentoMap : IEntityTypeConfiguration<TipoPagamento>
    {
        public void Configure(EntityTypeBuilder<TipoPagamento> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Descricao).IsRequired();
            builder.ToTable(nameof(TipoPagamento));
        }
    }
}
