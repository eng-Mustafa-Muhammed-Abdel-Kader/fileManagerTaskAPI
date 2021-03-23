using Microsoft.EntityFrameworkCore.Migrations;

namespace fileManagerTaskAPI.Migrations
{
    public partial class newUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fileType",
                table: "fileManagers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fileType",
                table: "fileManagers");
        }
    }
}
