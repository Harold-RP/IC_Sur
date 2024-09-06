using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IC_Sur.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Storage_StorageId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "StorageId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Storage_StorageId",
                table: "Products",
                column: "StorageId",
                principalTable: "Storage",
                principalColumn: "StorageId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Storage_StorageId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "StorageId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Storage_StorageId",
                table: "Products",
                column: "StorageId",
                principalTable: "Storage",
                principalColumn: "StorageId");
        }
    }
}
