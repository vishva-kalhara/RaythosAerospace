using Microsoft.EntityFrameworkCore.Migrations;

namespace RaythosAerospace101.Migrations
{
    public partial class addPlaneStatusis101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Planes");

            migrationBuilder.AddColumn<int>(
                name: "PlaneStatusId",
                table: "Planes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PlaneStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaneStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Planes_PlaneStatusId",
                table: "Planes",
                column: "PlaneStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Planes_PlaneStatuses_PlaneStatusId",
                table: "Planes",
                column: "PlaneStatusId",
                principalTable: "PlaneStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planes_PlaneStatuses_PlaneStatusId",
                table: "Planes");

            migrationBuilder.DropTable(
                name: "PlaneStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Planes_PlaneStatusId",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "PlaneStatusId",
                table: "Planes");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Planes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
