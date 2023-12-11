using Microsoft.EntityFrameworkCore.Migrations;

namespace RaythosAerospace101.Migrations
{
    public partial class addUserRoleTable__Fixed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_UserRoleRoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserRoleRoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserRoleRoleId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "UserRoles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserRoleRoleId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleRoleId",
                table: "Users",
                column: "UserRoleRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_UserRoleRoleId",
                table: "Users",
                column: "UserRoleRoleId",
                principalTable: "UserRoles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
