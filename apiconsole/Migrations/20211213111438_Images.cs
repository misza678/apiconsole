using Microsoft.EntityFrameworkCore.Migrations;

namespace apiconsole.Migrations
{
    public partial class Images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "CollectionItem");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Images",
                newName: "ImageSrc");

            migrationBuilder.AddColumn<int>(
                name: "CollectionItemId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_CollectionItemId",
                table: "Images",
                column: "CollectionItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_CollectionItem_CollectionItemId",
                table: "Images",
                column: "CollectionItemId",
                principalTable: "CollectionItem",
                principalColumn: "CollectionItemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_CollectionItem_CollectionItemId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_CollectionItemId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "CollectionItemId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "ImageSrc",
                table: "Images",
                newName: "ImageName");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "CollectionItem",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
