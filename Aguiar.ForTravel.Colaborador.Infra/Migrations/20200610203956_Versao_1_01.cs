using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aguiar.ForTravel.Colaborador.Infra.Migrations
{
    public partial class Versao_1_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Apelido = table.Column<string>(type: "varchar(150)", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UsuarioId = table.Column<string>(type: "varchar(150)", nullable: true),
                    Email = table.Column<string>(type: "varchar(150)", nullable: true),
                    FuncaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoBanco = table.Column<string>(type: "varchar(3)", nullable: true),
                    NomeBanco = table.Column<string>(type: "varchar(100)", nullable: true),
                    CodigoAgencia = table.Column<string>(type: "varchar(10)", nullable: true),
                    DigitoAgencia = table.Column<string>(type: "varchar(5)", nullable: true),
                    NomeAgencia = table.Column<string>(type: "varchar(100)", nullable: true),
                    ContaCorrente = table.Column<string>(type: "varchar(50)", nullable: true),
                    DigitoConta = table.Column<string>(type: "varchar(5)", nullable: true),
                    DadosConta_Favorecido = table.Column<string>(type: "varchar(150)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaboradores_Funcao_FuncaoId",
                        column: x => x.FuncaoId,
                        principalTable: "Funcao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TiposPagamentoColaborador",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoPagamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColaboradorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPagamentoColaborador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposPagamentoColaborador_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TiposPagamentoColaborador_TipoPagamento_TipoPagamentoId",
                        column: x => x.TipoPagamentoId,
                        principalTable: "TipoPagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_FuncaoId",
                table: "Colaboradores",
                column: "FuncaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposPagamentoColaborador_ColaboradorId",
                table: "TiposPagamentoColaborador",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposPagamentoColaborador_TipoPagamentoId",
                table: "TiposPagamentoColaborador",
                column: "TipoPagamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TiposPagamentoColaborador");

            migrationBuilder.DropTable(
                name: "Colaboradores");
        }
    }
}
