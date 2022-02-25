using Microsoft.EntityFrameworkCore.Migrations;

namespace apiconsole.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefectType",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DefectType",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
