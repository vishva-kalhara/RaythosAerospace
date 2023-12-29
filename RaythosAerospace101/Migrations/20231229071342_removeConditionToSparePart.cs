using Microsoft.EntityFrameworkCore.Migrations;

namespace RaythosAerospace101.Migrations
{
    public partial class removeConditionToSparePart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpareParts_SPConditions_SPConditionId",
                table: "SpareParts");

            migrationBuilder.DropTable(
                name: "SPConditions");

            migrationBuilder.DropIndex(
                name: "IX_SpareParts_SPConditionId",
                table: "SpareParts");

            migrationBuilder.DropColumn(
                name: "SPConditionId",
                table: "SpareParts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SPConditionId",
                table: "SpareParts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SPConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPConditions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpareParts_SPConditionId",
                table: "SpareParts",
                column: "SPConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpareParts_SPConditions_SPConditionId",
                table: "SpareParts",
                column: "SPConditionId",
                principalTable: "SPConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
