﻿// <auto-generated />
using System;
using Aguiar.ForTravel.Colaborador.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aguiar.ForTravel.Colaborador.Infra.Migrations
{
    [DbContext(typeof(ColaboradorDataContext))]
    [Migration("20200427180232_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aguiar.ForTravel.Colaborador.Domain.Models.Funcao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<decimal?>("LimiteOrcamentoViagem")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("PermitirAutorizarViagem")
                        .HasColumnType("bit");

                    b.Property<bool>("PermitirCriarViagem")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Funcao");
                });
#pragma warning restore 612, 618
        }
    }
}
