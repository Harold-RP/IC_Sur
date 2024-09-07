using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IC_Sur.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageEntries_Products_ProductId",
                table: "StorageEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_StorageEntries_Providers_ProviderId",
                table: "StorageEntries");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageEntries_Products_ProductId",
                table: "StorageEntries",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageEntries_Providers_ProviderId",
                table: "StorageEntries",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "ProviderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageEntries_Products_ProductId",
                table: "StorageEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_StorageEntries_Providers_ProviderId",
                table: "StorageEntries");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageEntries_Products_ProductId",
                table: "StorageEntries",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StorageEntries_Providers_ProviderId",
                table: "StorageEntries",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "ProviderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
