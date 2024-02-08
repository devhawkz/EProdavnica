using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EProdavnica.Server.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOfDigiUrlImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 8,
                column: "SlikaUrl",
                value: "https://www.biljaca.rs/wp-content/uploads/2022/10/digi4.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 8,
                column: "SlikaUrl",
                value: "https://www.biljaca.rs/product/wtl-mig-220-digi-synergic/?v=12af82c71473");
        }
    }
}
