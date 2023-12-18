using Microsoft.EntityFrameworkCore.Migrations;

namespace RaythosAerospace101.Migrations
{
    public partial class changed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomizedPlanes_overallStatuses_OverallStatusId",
                table: "CustomizedPlanes");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_spareParts_SparePartId",
                table: "Inventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_spareParts",
                table: "spareParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_overallStatuses",
                table: "overallStatuses");

            migrationBuilder.RenameTable(
                name: "spareParts",
                newName: "SpareParts");

            migrationBuilder.RenameTable(
                name: "overallStatuses",
                newName: "OverallStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpareParts",
                table: "SpareParts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OverallStatuses",
                table: "OverallStatuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomizedPlanes_OverallStatuses_OverallStatusId",
                table: "CustomizedPlanes",
                column: "OverallStatusId",
                principalTable: "OverallStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_SpareParts_SparePartId",
                table: "Inventories",
                column: "SparePartId",
                principalTable: "SpareParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomizedPlanes_OverallStatuses_OverallStatusId",
                table: "CustomizedPlanes");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_SpareParts_SparePartId",
                table: "Inventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpareParts",
                table: "SpareParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OverallStatuses",
                table: "OverallStatuses");

            migrationBuilder.RenameTable(
                name: "SpareParts",
                newName: "spareParts");

            migrationBuilder.RenameTable(
                name: "OverallStatuses",
                newName: "overallStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_spareParts",
                table: "spareParts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_overallStatuses",
                table: "overallStatuses",
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
        }
    }
}
