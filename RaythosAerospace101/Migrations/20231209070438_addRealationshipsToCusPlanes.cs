using Microsoft.EntityFrameworkCore.Migrations;

namespace RaythosAerospace101.Migrations
{
    public partial class addRealationshipsToCusPlanes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "CustomizedPlanes");

            migrationBuilder.AddColumn<int>(
                name: "FloorPlanId",
                table: "CustomizedPlanes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OverallStatusId",
                table: "CustomizedPlanes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlaneDesignSchemeId",
                table: "CustomizedPlanes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlaneId",
                table: "CustomizedPlanes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "CustomizedPlanes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OverallStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverallStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomizedPlanes_FloorPlanId",
                table: "CustomizedPlanes",
                column: "FloorPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomizedPlanes_OverallStatusId",
                table: "CustomizedPlanes",
                column: "OverallStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomizedPlanes_PlaneDesignSchemeId",
                table: "CustomizedPlanes",
                column: "PlaneDesignSchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomizedPlanes_PlaneId",
                table: "CustomizedPlanes",
                column: "PlaneId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomizedPlanes_UserEmail",
                table: "CustomizedPlanes",
                column: "UserEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomizedPlanes_FloorPlans_FloorPlanId",
                table: "CustomizedPlanes",
                column: "FloorPlanId",
                principalTable: "FloorPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomizedPlanes_OverallStatus_OverallStatusId",
                table: "CustomizedPlanes",
                column: "OverallStatusId",
                principalTable: "OverallStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomizedPlanes_PlaneDesignSchemes_PlaneDesignSchemeId",
                table: "CustomizedPlanes",
                column: "PlaneDesignSchemeId",
                principalTable: "PlaneDesignSchemes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomizedPlanes_Planes_PlaneId",
                table: "CustomizedPlanes",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomizedPlanes_Users_UserEmail",
                table: "CustomizedPlanes",
                column: "UserEmail",
                principalTable: "Users",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomizedPlanes_FloorPlans_FloorPlanId",
                table: "CustomizedPlanes");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomizedPlanes_OverallStatus_OverallStatusId",
                table: "CustomizedPlanes");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomizedPlanes_PlaneDesignSchemes_PlaneDesignSchemeId",
                table: "CustomizedPlanes");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomizedPlanes_Planes_PlaneId",
                table: "CustomizedPlanes");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomizedPlanes_Users_UserEmail",
                table: "CustomizedPlanes");

            migrationBuilder.DropTable(
                name: "OverallStatus");

            migrationBuilder.DropIndex(
                name: "IX_CustomizedPlanes_FloorPlanId",
                table: "CustomizedPlanes");

            migrationBuilder.DropIndex(
                name: "IX_CustomizedPlanes_OverallStatusId",
                table: "CustomizedPlanes");

            migrationBuilder.DropIndex(
                name: "IX_CustomizedPlanes_PlaneDesignSchemeId",
                table: "CustomizedPlanes");

            migrationBuilder.DropIndex(
                name: "IX_CustomizedPlanes_PlaneId",
                table: "CustomizedPlanes");

            migrationBuilder.DropIndex(
                name: "IX_CustomizedPlanes_UserEmail",
                table: "CustomizedPlanes");

            migrationBuilder.DropColumn(
                name: "FloorPlanId",
                table: "CustomizedPlanes");

            migrationBuilder.DropColumn(
                name: "OverallStatusId",
                table: "CustomizedPlanes");

            migrationBuilder.DropColumn(
                name: "PlaneDesignSchemeId",
                table: "CustomizedPlanes");

            migrationBuilder.DropColumn(
                name: "PlaneId",
                table: "CustomizedPlanes");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "CustomizedPlanes");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "CustomizedPlanes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
