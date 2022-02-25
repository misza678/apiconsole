using Microsoft.EntityFrameworkCore.Migrations;

namespace apiconsole.Migrations
{
    public partial class productfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "ProductType",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
