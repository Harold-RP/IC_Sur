using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IC_Sur.Migrations
{
    /// <inheritdoc />
    public partial class FixStorageEntryProviderRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageEntries_Providers_ProviderId1",
                table: "StorageEntries");

            migrationBuilder.DropIndex(
                name: "IX_StorageEntries_ProviderId1",
                table: "StorageEntries");

            migrationBuilder.DropColumn(
                name: "ProviderId1",
                table: "StorageEntries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProviderId1",
                table: "StorageEntries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageEntries_ProviderId1",
                table: "StorageEntries",
                column: "ProviderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageEntries_Providers_ProviderId1",
                table: "StorageEntries",
                column: "ProviderId1",
                principalTable: "Providers",
                principalColumn: "ProviderId");
        }
    }
}
