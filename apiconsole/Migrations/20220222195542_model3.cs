using Microsoft.EntityFrameworkCore.Migrations;

namespace apiconsole.Migrations
{
    public partial class model3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DefectModel",
                columns: table => new
                {
                    DefectID = table.Column<int>(type: "int", nullable: false),
                    ModelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefectModel", x => new { x.DefectID, x.ModelID });
                    table.ForeignKey(
                        name: "FK_DefectModel_Defect_DefectID",
                        column: x => x.DefectID,
                        principalTable: "Defect",
                        principalColumn: "DefectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DefectModel_Model_ModelID",
                        column: x => x.ModelID,
                        principalTable: "Model",
                        principalColumn: "ModelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DefectModel_ModelID",
                table: "DefectModel",
                column: "ModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefectModel");
        }
    }
}
