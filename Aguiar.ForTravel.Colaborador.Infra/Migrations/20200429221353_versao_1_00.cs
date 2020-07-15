using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aguiar.ForTravel.Colaborador.Infra.Migrations
{
    public partial class versao_1_00 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoPagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(150)", nullable: false),
                    RequerDadosCartao = table.Column<bool>(type: "bit", nullable: false),
                    EhCartaoCorporativo = table.Column<bool>(type: "bit", nullable: false),
                    RequerDadosConta = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPagamento", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoPagamento");
        }
    }
}
