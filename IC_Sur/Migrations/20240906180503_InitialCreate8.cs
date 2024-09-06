using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IC_Sur.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StorageLocation",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StorageLocation",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
