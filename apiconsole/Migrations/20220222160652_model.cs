using Microsoft.EntityFrameworkCore.Migrations;

namespace apiconsole.Migrations
{
    public partial class model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Model_Product_ProductID",
                table: "Model");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Model",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Model",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Model_CategoryID",
                table: "Model",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Model_Category_CategoryID",
                table: "Model",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Model_Product_ProductID",
                table: "Model",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Model_Category_CategoryID",
                table: "Model");

            migrationBuilder.DropForeignKey(
                name: "FK_Model_Product_ProductID",
                table: "Model");

            migrationBuilder.DropIndex(
                name: "IX_Model_CategoryID",
                table: "Model");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Model");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Model",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Model_Product_ProductID",
                table: "Model",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryID",
                table: "Product",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
