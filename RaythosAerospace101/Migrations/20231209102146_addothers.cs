using Microsoft.EntityFrameworkCore.Migrations;

namespace RaythosAerospace101.Migrations
{
    public partial class addothers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomizedPlanes_OverallStatus_OverallStatusId",
                table: "CustomizedPlanes");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_SparePart_SparePartId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_InvInvoice_Inventory_InventoryId",
                table: "InvInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_InvInvoice_Users_UserEmail",
                table: "InvInvoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SparePart",
                table: "SparePart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OverallStatus",
                table: "OverallStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvInvoice",
                table: "InvInvoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventory",
                table: "Inventory");

            migrationBuilder.RenameTable(
                name: "SparePart",
                newName: "spareParts");

            migrationBuilder.RenameTable(
                name: "OverallStatus",
                newName: "overallStatuses");

            migrationBuilder.RenameTable(
                name: "InvInvoice",
                newName: "InvInvoices");

            migrationBuilder.RenameTable(
                name: "Inventory",
                newName: "Inventories");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Planes",
                newName: "Price");

            migrationBuilder.RenameIndex(
                name: "IX_InvInvoice_UserEmail",
                table: "InvInvoices",
                newName: "IX_InvInvoices_UserEmail");

            migrationBuilder.RenameIndex(
                name: "IX_InvInvoice_InventoryId",
                table: "InvInvoices",
                newName: "IX_InvInvoices_InventoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_SparePartId",
                table: "Inventories",
                newName: "IX_Inventories_SparePartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_spareParts",
                table: "spareParts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_overallStatuses",
                table: "overallStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvInvoices",
                table: "InvInvoices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomizedPlanes_overallStatuses_OverallStatusId",
                table: "CustomizedPlanes",
                column: "OverallStatusId",
                principalTable: "overallStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_spareParts_SparePartId",
                table: "Inventories",
                column: "SparePartId",
                principalTable: "spareParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvInvoices_Inventories_InventoryId",
                table: "InvInvoices",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvInvoices_Users_UserEmail",
                table: "InvInvoices",
                column: "UserEmail",
                principalTable: "Users",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomizedPlanes_overallStatuses_OverallStatusId",
                table: "CustomizedPlanes");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_spareParts_SparePartId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_InvInvoices_Inventories_InventoryId",
                table: "InvInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_InvInvoices_Users_UserEmail",
                table: "InvInvoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_spareParts",
                table: "spareParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_overallStatuses",
                table: "overallStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvInvoices",
                table: "InvInvoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories");

            migrationBuilder.RenameTable(
                name: "spareParts",
                newName: "SparePart");

            migrationBuilder.RenameTable(
                name: "overallStatuses",
                newName: "OverallStatus");

            migrationBuilder.RenameTable(
                name: "InvInvoices",
                newName: "InvInvoice");

            migrationBuilder.RenameTable(
                name: "Inventories",
                newName: "Inventory");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Planes",
                newName: "price");

            migrationBuilder.RenameIndex(
                name: "IX_InvInvoices_UserEmail",
                table: "InvInvoice",
                newName: "IX_InvInvoice_UserEmail");

            migrationBuilder.RenameIndex(
                name: "IX_InvInvoices_InventoryId",
                table: "InvInvoice",
                newName: "IX_InvInvoice_InventoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventories_SparePartId",
                table: "Inventory",
                newName: "IX_Inventory_SparePartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SparePart",
                table: "SparePart",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OverallStatus",
                table: "OverallStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvInvoice",
                table: "InvInvoice",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventory",
                table: "Inventory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomizedPlanes_OverallStatus_OverallStatusId",
                table: "CustomizedPlanes",
                column: "OverallStatusId",
                principalTable: "OverallStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_SparePart_SparePartId",
                table: "Inventory",
                column: "SparePartId",
                principalTable: "SparePart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvInvoice_Inventory_InventoryId",
                table: "InvInvoice",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvInvoice_Users_UserEmail",
                table: "InvInvoice",
                column: "UserEmail",
                principalTable: "Users",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
