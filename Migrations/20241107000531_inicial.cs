using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TarjetasCuentasAPI.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDeCuenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moneda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuentas_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarjetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emisor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarjetas_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "John Doe" },
                    { 2, "Jane Smith" },
                    { 3, "William Johnson" }
                });

            migrationBuilder.InsertData(
                table: "Cuentas",
                columns: new[] { "Id", "Estado", "IdCliente", "Moneda", "NumeroDeCuenta", "Tipo" },
                values: new object[,]
                {
                    { 1, "ACTIVA", 1, "CRC", "1234567890", "AHO" },
                    { 2, "ACTIVA", 1, "CRC", "0987654321", "AHO" },
                    { 3, "ACTIVA", 2, "CRC", "1122334455", "AHO" },
                    { 4, "ACTIVA", 3, "CRC", "5544332211", "AHO" },
                    { 5, "ACTIVA", 3, "CRC", "6677889900", "AHO" }
                });

            migrationBuilder.InsertData(
                table: "Tarjetas",
                columns: new[] { "Id", "Emisor", "Estado", "FechaVencimiento", "IdCliente", "Numero" },
                values: new object[,]
                {
                    { 1, "VISA", "ACTIVA", new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "4111111111111111" },
                    { 2, "VISA", "ACTIVA", new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "4222222222222222" },
                    { 3, "VISA", "ACTIVA", new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "4333333333333333" },
                    { 4, "VISA", "ACTIVA", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "4444444444444444" },
                    { 5, "VISA", "ACTIVA", new DateTime(2026, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "4555555555555555" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_IdCliente",
                table: "Cuentas",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjetas_IdCliente",
                table: "Tarjetas",
                column: "IdCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Tarjetas");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
