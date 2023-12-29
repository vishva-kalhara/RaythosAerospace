using Microsoft.EntityFrameworkCore.Migrations;

namespace RaythosAerospace101.Migrations
{
    public partial class removeInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvInvoices_Users_UserEmail",
                table: "InvInvoices");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvInvoices",
                table: "InvInvoices");

            migrationBuilder.RenameTable(
                name: "InvInvoices",
                newName: "InvInvoice");

            migrationBuilder.RenameIndex(
                name: "IX_InvInvoices_UserEmail",
                table: "InvInvoice",
                newName: "IX_InvInvoice_UserEmail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvInvoice",
                table: "InvInvoice",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvInvoice_Users_UserEmail",
                table: "InvInvoice",
                column: "UserEmail",
                principalTable: "Users",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvInvoice_Users_UserEmail",
                table: "InvInvoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvInvoice",
                table: "InvInvoice");

            migrationBuilder.RenameTable(
                name: "InvInvoice",
                newName: "InvInvoices");

            migrationBuilder.RenameIndex(
                name: "IX_InvInvoice_UserEmail",
                table: "InvInvoices",
                newName: "IX_InvInvoices_UserEmail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvInvoices",
                table: "InvInvoices",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_InvInvoices_Users_UserEmail",
                table: "InvInvoices",
                column: "UserEmail",
                principalTable: "Users",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
