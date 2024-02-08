using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EProdavnica.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategorijaId",
                table: "Proizvodi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Kategorije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorije", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Kategorije",
                columns: new[] { "Id", "Ime", "Url" },
                values: new object[,]
                {
                    { 1, "Elektrolučno zavarivanje", "elektro" },
                    { 2, "MIG/MAG zavarivanje", "mig-mag" },
                    { 3, "Plazma rezanje", "plazma" }
                });

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 1,
                column: "KategorijaId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 2,
                column: "KategorijaId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 3,
                column: "KategorijaId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodi_KategorijaId",
                table: "Proizvodi",
                column: "KategorijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvodi_Kategorije_KategorijaId",
                table: "Proizvodi",
                column: "KategorijaId",
                principalTable: "Kategorije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proizvodi_Kategorije_KategorijaId",
                table: "Proizvodi");

            migrationBuilder.DropTable(
                name: "Kategorije");

            migrationBuilder.DropIndex(
                name: "IX_Proizvodi_KategorijaId",
                table: "Proizvodi");

            migrationBuilder.DropColumn(
                name: "KategorijaId",
                table: "Proizvodi");
        }
    }
}
