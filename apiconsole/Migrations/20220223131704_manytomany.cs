using Microsoft.EntityFrameworkCore.Migrations;

namespace apiconsole.Migrations
{
    public partial class manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefectModel_Model_ModelID",
                table: "DefectModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Model_Category_CategoryID",
                table: "Model");

            migrationBuilder.DropForeignKey(
                name: "FK_Model_Product_ProductID",
                table: "Model");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DefectModel",
                table: "DefectModel");

            migrationBuilder.DropIndex(
                name: "IX_DefectModel_ModelID",
                table: "DefectModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Model",
                table: "Model");

            migrationBuilder.RenameTable(
                name: "Model",
                newName: "Models");

            migrationBuilder.RenameIndex(
                name: "IX_Model_ProductID",
                table: "Models",
                newName: "IX_Models_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Model_CategoryID",
                table: "Models",
                newName: "IX_Models_CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DefectModel",
                table: "DefectModel",
                columns: new[] { "ModelID", "DefectID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Models",
                table: "Models",
                column: "ModelID");

            migrationBuilder.CreateIndex(
                name: "IX_DefectModel_DefectID",
                table: "DefectModel",
                column: "DefectID");

            migrationBuilder.AddForeignKey(
                name: "FK_DefectModel_Models_ModelID",
                table: "DefectModel",
                column: "ModelID",
                principalTable: "Models",
                principalColumn: "ModelID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Category_CategoryID",
                table: "Models",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Product_ProductID",
                table: "Models",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefectModel_Models_ModelID",
                table: "DefectModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Category_CategoryID",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Product_ProductID",
                table: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DefectModel",
                table: "DefectModel");

            migrationBuilder.DropIndex(
                name: "IX_DefectModel_DefectID",
                table: "DefectModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Models",
                table: "Models");

            migrationBuilder.RenameTable(
                name: "Models",
                newName: "Model");

            migrationBuilder.RenameIndex(
                name: "IX_Models_ProductID",
                table: "Model",
                newName: "IX_Model_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Models_CategoryID",
                table: "Model",
                newName: "IX_Model_CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DefectModel",
                table: "DefectModel",
                columns: new[] { "DefectID", "ModelID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Model",
                table: "Model",
                column: "ModelID");

            migrationBuilder.CreateIndex(
                name: "IX_DefectModel_ModelID",
                table: "DefectModel",
                column: "ModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_DefectModel_Model_ModelID",
                table: "DefectModel",
                column: "ModelID",
                principalTable: "Model",
                principalColumn: "ModelID",
                onDelete: ReferentialAction.Cascade);

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
    }
}
