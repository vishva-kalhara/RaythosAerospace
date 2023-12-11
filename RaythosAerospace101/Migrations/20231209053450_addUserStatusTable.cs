using Microsoft.EntityFrameworkCore.Migrations;

namespace RaythosAerospace101.Migrations
{
    public partial class addUserStatusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsrStatusId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserStatus",
                columns: table => new
                {
                    UsrStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsrStatusValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatus", x => x.UsrStatusId);
                });

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

            migrationBuilder.DropTable(
                name: "UserStatus");

            migrationBuilder.DropIndex(
                name: "IX_Users_UsrStatusId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UsrStatusId",
                table: "Users");
        }
    }
}
