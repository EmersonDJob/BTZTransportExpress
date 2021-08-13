using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BTZTransportExpress.Data.Migrations
{
    public partial class Um : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motoristas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaCNH = table.Column<int>(type: "int", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoristas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeVeiculo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoCombustivel = table.Column<int>(type: "int", nullable: false),
                    Fabricante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnoFabricacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxTanque = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Abastecimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VeiculoId = table.Column<int>(type: "int", nullable: false),
                    MotoristaId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoCombustivel = table.Column<int>(type: "int", nullable: false),
                    QuantidadeCombustivel = table.Column<double>(type: "float", nullable: false),
                    ValorTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abastecimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abastecimentos_Motoristas_MotoristaId",
                        column: x => x.MotoristaId,
                        principalTable: "Motoristas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Abastecimentos_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abastecimentos_MotoristaId",
                table: "Abastecimentos",
                column: "MotoristaId");

            migrationBuilder.CreateIndex(
                name: "IX_Abastecimentos_VeiculoId",
                table: "Abastecimentos",
                column: "VeiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abastecimentos");

            migrationBuilder.DropTable(
                name: "Motoristas");

            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
