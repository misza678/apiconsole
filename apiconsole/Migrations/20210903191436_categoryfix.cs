using Microsoft.EntityFrameworkCore.Migrations;

namespace apiconsole.Migrations
{
    public partial class categoryfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainProductToView_Category_CategoryId",
                table: "MainProductToView");

            migrationBuilder.DropIndex(
                name: "IX_MainProductToView_CategoryId",
                table: "MainProductToView");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "MainProductToView");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "MainProductToView",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MainProductToView_CategoryId",
                table: "MainProductToView",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainProductToView_Category_CategoryId",
                table: "MainProductToView",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
