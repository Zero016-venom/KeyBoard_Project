using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASSIGN_Data.Migrations
{
    public partial class Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ten",
                table: "SanPham",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ten",
                table: "SanPham");
        }
    }
}
