using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aguiar.ForTravel.Colaborador.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(150)", nullable: false),
                    PermitirAutorizarViagem = table.Column<bool>(nullable: false),
                    PermitirCriarViagem = table.Column<bool>(nullable: false),
                    LimiteOrcamentoViagem = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcao", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcao");
        }
    }
}
