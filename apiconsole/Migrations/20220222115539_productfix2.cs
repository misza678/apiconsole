using Microsoft.EntityFrameworkCore.Migrations;

namespace apiconsole.Migrations
{
    public partial class productfix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "Product");

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    ModelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    PhotoSRC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.ModelID);
                    table.ForeignKey(
                        name: "FK_Model_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Model_ProductID",
                table: "Model",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
