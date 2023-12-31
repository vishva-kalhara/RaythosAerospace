using Microsoft.EntityFrameworkCore.Migrations;

namespace RaythosAerospace101.Migrations
{
    public partial class addQtyToSparePartsOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "currentDateTime",
                table: "SparePartOrders",
                newName: "CurrentDateTime");

            migrationBuilder.AddColumn<int>(
                name: "Qty",
                table: "SparePartOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qty",
                table: "SparePartOrders");

            migrationBuilder.RenameColumn(
                name: "CurrentDateTime",
                table: "SparePartOrders",
                newName: "currentDateTime");
        }
    }
}
