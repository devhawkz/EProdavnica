using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EProdavnica.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddFeaturedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Preporuceni",
                table: "Proizvodi",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 1,
                column: "Preporuceni",
                value: true);

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 2,
                column: "Preporuceni",
                value: false);

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 3,
                column: "Preporuceni",
                value: false);

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 4,
                column: "Preporuceni",
                value: true);

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 5,
                column: "Preporuceni",
                value: false);

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 6,
                column: "Preporuceni",
                value: true);

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 7,
                column: "Preporuceni",
                value: false);

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 8,
                column: "Preporuceni",
                value: true);

            migrationBuilder.UpdateData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 9,
                column: "Preporuceni",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preporuceni",
                table: "Proizvodi");
        }
    }
}
