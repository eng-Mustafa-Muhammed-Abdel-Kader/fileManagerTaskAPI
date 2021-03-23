using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace fileManagerTaskAPI.Migrations
{
    public partial class newMigrationToFileManagerTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fileManagers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descreption = table.Column<string>(maxLength: 200, nullable: true),
                    DocumentURL = table.Column<string>(maxLength: 200, nullable: true),
                    CreatationDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fileManagers", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fileManagers");
        }
    }
}
