using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EProdavnica.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUrlOfImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 1,
                column: "SlikaUrl",
                value: "https://www.biljaca.rs/wp-content/uploads/2019/01/aparat-zavarivanje-wtl-multimig-200-slika-42091184-300x300-2.jpg");

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 2,
                column: "SlikaUrl",
                value: "https://www.biljaca.rs/wp-content/uploads/2023/05/easy-job-200.jpg");

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 4,
                column: "SlikaUrl",
                value: "https://www.biljaca.rs/wp-content/uploads/2021/04/tt2000.jpg");

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 5,
                column: "SlikaUrl",
                value: "https://www.biljaca.rs/wp-content/uploads/2020/05/big-53583055_5a1c62bf275d96-73145320tig_ac-dc_320-1--300x300.jpg");

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 6,
                column: "SlikaUrl",
                value: "https://www.biljaca.rs/wp-content/uploads/2021/03/aristo500ix-1.jpg");

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 7,
                column: "SlikaUrl",
                value: "https://www.biljaca.rs/wp-content/uploads/2019/01/cut_100_cnc_fotor.jpg");

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 8,
                column: "SlikaUrl",
                value: "https://www.biljaca.rs/product/wtl-mig-220-digi-synergic/?v=12af82c71473");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 1,
                column: "SlikaUrl",
                value: "https://www.sualati.com/files/product_picture/2019.07.11.14.16.25_5d272899aaebd_mig315a.jpg");

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 2,
                column: "SlikaUrl",
                value: "https://www.sualati.com/files/product_picture/605c73c8ac430_wtl-easy-job-200.jpg");

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 4,
                column: "SlikaUrl",
                value: "https://www.wtl.si/media/catalog/product/cache/1/image/363x/83ec0365e1c5f79d81549ee4449e1b43/t/p/tp_2000.jpg");

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 5,
                column: "SlikaUrl",
                value: "https://www.wtl.si/media/catalog/product/cache/1/image/363x/83ec0365e1c5f79d81549ee4449e1b43/t/i/tig_ac-dc_320.jpg");

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 6,
                column: "SlikaUrl",
                value: "https://www.sualati.com/files/product_picture/659d524600d9f_aristo-500ix-pulse-robust-u6-1650528918-8531.jpg");

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 7,
                column: "SlikaUrl",
                value: "https://www.sualati.com/files/product_picture/2019.07.11.14.16.25_5d272899aaebd_mig315a.jpg");

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 8,
                column: "SlikaUrl",
                value: "https://www.wtl.si/media/catalog/product/cache/1/image/363x/83ec0365e1c5f79d81549ee4449e1b43/m/i/mig220_profile_002__1.jpg");
        }
    }
}
