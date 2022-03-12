using Microsoft.EntityFrameworkCore.Migrations;

namespace apiconsole.Migrations
{
    public partial class productModelFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionItem_Product_ProductID",
                table: "CollectionItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Repair_Product_ProductID",
                table: "Repair");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Repair",
                newName: "ModelID");

            migrationBuilder.RenameIndex(
                name: "IX_Repair_ProductID",
                table: "Repair",
                newName: "IX_Repair_ModelID");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "CollectionItem",
                newName: "ModelID");

            migrationBuilder.RenameIndex(
                name: "IX_CollectionItem_ProductID",
                table: "CollectionItem",
                newName: "IX_CollectionItem_ModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionItem_Models_ModelID",
                table: "CollectionItem",
                column: "ModelID",
                principalTable: "Models",
                principalColumn: "ModelID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repair_Models_ModelID",
                table: "Repair",
                column: "ModelID",
                principalTable: "Models",
                principalColumn: "ModelID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionItem_Models_ModelID",
                table: "CollectionItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Repair_Models_ModelID",
                table: "Repair");

            migrationBuilder.RenameColumn(
                name: "ModelID",
                table: "Repair",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Repair_ModelID",
                table: "Repair",
                newName: "IX_Repair_ProductID");

            migrationBuilder.RenameColumn(
                name: "ModelID",
                table: "CollectionItem",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_CollectionItem_ModelID",
                table: "CollectionItem",
                newName: "IX_CollectionItem_ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionItem_Product_ProductID",
                table: "CollectionItem",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repair_Product_ProductID",
                table: "Repair",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
