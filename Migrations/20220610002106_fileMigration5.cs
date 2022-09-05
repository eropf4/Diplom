using Microsoft.EntityFrameworkCore.Migrations;

namespace Diplom.Auth.Migrations
{
    public partial class fileMigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Review",
                table: "UserTasks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Review",
                table: "UserTasks");
        }
    }
}
