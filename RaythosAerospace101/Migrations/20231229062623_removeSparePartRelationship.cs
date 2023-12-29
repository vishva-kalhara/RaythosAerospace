using Microsoft.EntityFrameworkCore.Migrations;

namespace RaythosAerospace101.Migrations
{
    public partial class removeSparePartRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_SpareParts_SparePartId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_InvInvoices_Inventories_InventoryId",
                table: "InvInvoices");

            migrationBuilder.DropIndex(
                name: "IX_InvInvoices_InventoryId",
                table: "InvInvoices");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_SparePartId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "InvInvoices");

            migrationBuilder.DropColumn(
                name: "SparePartId",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "Qty",
                table: "SpareParts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qty",
                table: "SpareParts");

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "InvInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SparePartId",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InvInvoices_InventoryId",
                table: "InvInvoices",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_SparePartId",
                table: "Inventories",
                column: "SparePartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_SpareParts_SparePartId",
                table: "Inventories",
                column: "SparePartId",
                principalTable: "SpareParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvInvoices_Inventories_InventoryId",
                table: "InvInvoices",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
