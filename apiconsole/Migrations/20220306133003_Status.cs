using Microsoft.EntityFrameworkCore.Migrations;

namespace apiconsole.Migrations
{
    public partial class Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "Repair",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "CollectionItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Repair_StatusID",
                table: "Repair",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionItem_StatusID",
                table: "CollectionItem",
                column: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionItem_Status_StatusID",
                table: "CollectionItem",
                column: "StatusID",
                principalTable: "Status",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repair_Status_StatusID",
                table: "Repair",
                column: "StatusID",
                principalTable: "Status",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionItem_Status_StatusID",
                table: "CollectionItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Repair_Status_StatusID",
                table: "Repair");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Repair_StatusID",
                table: "Repair");

            migrationBuilder.DropIndex(
                name: "IX_CollectionItem_StatusID",
                table: "CollectionItem");

            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "Repair");

            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "CollectionItem");
        }
    }
}
