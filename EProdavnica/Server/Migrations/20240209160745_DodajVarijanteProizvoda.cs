using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EProdavnica.Server.Migrations
{
    /// <inheritdoc />
    public partial class DodajVarijanteProizvoda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cena",
                table: "Proizvodi");

            migrationBuilder.CreateTable(
                name: "TipoviProizvoda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoviProizvoda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VarijanteProizvoda",
                columns: table => new
                {
                    ProizvodId = table.Column<int>(type: "int", nullable: false),
                    TipProizvodaId = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalnaCena = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VarijanteProizvoda", x => new { x.ProizvodId, x.TipProizvodaId });
                    table.ForeignKey(
                        name: "FK_VarijanteProizvoda_Proizvodi_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvodi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VarijanteProizvoda_TipoviProizvoda_TipProizvodaId",
                        column: x => x.TipProizvodaId,
                        principalTable: "TipoviProizvoda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoviProizvoda",
                columns: new[] { "Id", "Ime" },
                values: new object[,]
                {
                    { 1, "Osnovno" },
                    { 2, "Sa gorionikom od 250A" },
                    { 3, "Sa gorionikom od 360A" },
                    { 4, "Sa gorionikom sa vodenim hlađenjem od 500A" },
                    { 5, "Sa gorionikom WP17" },
                    { 6, "Sa gorionikom WP18" },
                    { 7, "Sa mašinskim gorionikom" },
                    { 8, "Sa ručnim gorionikom" }
                });

            migrationBuilder.InsertData(
                table: "VarijanteProizvoda",
                columns: new[] { "ProizvodId", "TipProizvodaId", "Cena", "OriginalnaCena" },
                values: new object[,]
                {
                    { 1, 1, 10.99m, 11.99m },
                    { 1, 2, 12.99m, 11.99m },
                    { 1, 3, 13.99m, 11.99m },
                    { 2, 1, 4.99m, 6.99m },
                    { 3, 1, 20.99m, 22.99m },
                    { 3, 2, 21.99m, 22.99m },
                    { 3, 3, 22.99m, 22.99m },
                    { 4, 1, 12.99m, 15.99m },
                    { 4, 5, 13.99m, 15.99m },
                    { 4, 6, 14.99m, 16.99m },
                    { 5, 1, 25.99m, 30.99m },
                    { 5, 5, 26.99m, 30.99m },
                    { 5, 6, 27.99m, 30.99m },
                    { 6, 1, 45.99m, 50.99m },
                    { 6, 2, 46.99m, 50.99m },
                    { 6, 3, 47.99m, 50.99m },
                    { 6, 4, 48.99m, 50.99m },
                    { 7, 1, 32.99m, 35.99m },
                    { 7, 7, 33.99m, 35.99m },
                    { 7, 8, 34.99m, 35.99m },
                    { 8, 1, 7.99m, 10.99m },
                    { 8, 2, 8.99m, 11.99m },
                    { 9, 1, 8.99m, 10.99m },
                    { 9, 2, 9.99m, 11.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VarijanteProizvoda_TipProizvodaId",
                table: "VarijanteProizvoda",
                column: "TipProizvodaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VarijanteProizvoda");

            migrationBuilder.DropTable(
                name: "TipoviProizvoda");

            migrationBuilder.AddColumn<decimal>(
                name: "Cena",
                table: "Proizvodi",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 1,
                column: "Cena",
                value: 9.99m);

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 2,
                column: "Cena",
                value: 15.99m);

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 3,
                column: "Cena",
                value: 5.99m);

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 4,
                column: "Cena",
                value: 9.99m);

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 5,
                column: "Cena",
                value: 15.99m);

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 6,
                column: "Cena",
                value: 5.99m);

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 7,
                column: "Cena",
                value: 9.99m);

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 8,
                column: "Cena",
                value: 15.99m);

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 9,
                column: "Cena",
                value: 5.99m);
        }
    }
}
