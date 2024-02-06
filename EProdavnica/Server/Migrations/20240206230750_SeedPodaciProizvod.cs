using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EProdavnica.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedPodaciProizvod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Proizvodi",
                columns: new[] { "Id", "Cena", "Naziv", "Opis", "SlikaUrl" },
                values: new object[,]
                {
                    { 1, 9.99m, "WTL MIG 315", "Aparat za poluautomatsko zavarivanje u zastiti gasa.", "https://www.sualati.com/files/product_picture/2019.07.11.14.16.25_5d272899aaebd_mig315a.jpg" },
                    { 2, 15.99m, "WTL EASY JOB 200E", "Savrsen za kucnu upotrebu i lakse radionicke poslove!elektrolucni aparat , za celik i prohron", "https://www.sualati.com/files/product_picture/605c73c8ac430_wtl-easy-job-200.jpg" },
                    { 3, 5.99m, "WTL MIG 350F", "MIG/MAG Aparat za poluautomatsko zavarivanje u zaštiti gasa u izvedbi sa odvojenim dodvačem žice", "https://www.sualati.com/files/product_picture/2019.07.11.14.53.23_5d2731434735b_mig-350-a-wtl.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
