using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IC_Sur.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Storage");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Storage",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Section",
                table: "Storage",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Storage");

            migrationBuilder.DropColumn(
                name: "Section",
                table: "Storage");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Storage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
