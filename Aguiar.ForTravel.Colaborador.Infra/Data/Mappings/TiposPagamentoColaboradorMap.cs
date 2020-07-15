using Aguiar.ForTravel.Colaborador.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Colaborador.Infra.Data.Mappings
{
    public class TiposPagamentoColaboradorMap : IEntityTypeConfiguration<TiposPagamentoColaborador>
    {
        public void Configure(EntityTypeBuilder<TiposPagamentoColaborador> builder)
        {
            builder.HasKey(k => k.Id);
            builder.ToTable(nameof(TiposPagamentoColaborador));
        }

    }
}
