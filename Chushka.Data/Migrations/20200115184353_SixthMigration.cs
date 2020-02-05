using Microsoft.EntityFrameworkCore.Migrations;

namespace Chushka.Data.Migrations
{
    public partial class SixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductTypeId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
