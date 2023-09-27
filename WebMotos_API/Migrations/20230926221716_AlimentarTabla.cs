using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebMotos_API.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Motos",
                columns: new[] { "Id", "Año", "Bateria", "Cilindrada", "Color", "FechaActualizacion", "FechaCreacion", "Frenos", "ImagenUrl", "Marca", "Modelo", "Motor", "Peso", "Precio", "Rodado", "Suspension" },
                values: new object[,]
                {
                    { 1, 2018, "YTX7L-BS 12V 6Ah", "124 cc", "Rojo", new DateTime(2023, 9, 26, 19, 17, 16, 595, DateTimeKind.Local).AddTicks(9256), new DateTime(2023, 9, 26, 19, 17, 16, 595, DateTimeKind.Local).AddTicks(9241), "Disco / Tambor", "", "Yamaha", "YBR 125 ED", "Monocilíndrico, 4 tiempos", 123, 1367750.0, 18.0, "Doble amortiguador" },
                    { 2, 2017, "BB5LB 12V 5Ah", "107 cc", "Negro", new DateTime(2023, 9, 26, 19, 17, 16, 595, DateTimeKind.Local).AddTicks(9260), new DateTime(2023, 9, 26, 19, 17, 16, 595, DateTimeKind.Local).AddTicks(9259), "Disco / Tambor", "", "Gilera", "Smash 110 Tunning", "Monocilíndrico, 4 tiempos", 100, 623700.0, 13.0, "Doble amortiguador" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Motos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Motos",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
