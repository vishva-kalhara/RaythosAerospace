using Microsoft.EntityFrameworkCore.Migrations;

namespace RaythosAerospace101.Migrations
{
    public partial class addUserStatusTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserStatus_UserStatusUsrStatusId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserStatusUsrStatusId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserStatusUsrStatusId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UsrStatusId",
                table: "Users",
                column: "UsrStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserStatus_UsrStatusId",
                table: "Users",
                column: "UsrStatusId",
                principalTable: "UserStatus",
                principalColumn: "UsrStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserStatus_UsrStatusId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UsrStatusId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserStatusUsrStatusId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserStatusUsrStatusId",
                table: "Users",
                column: "UserStatusUsrStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserStatus_UserStatusUsrStatusId",
                table: "Users",
                column: "UserStatusUsrStatusId",
                principalTable: "UserStatus",
                principalColumn: "UsrStatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
