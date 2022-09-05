using Microsoft.EntityFrameworkCore.Migrations;

namespace Diplom.Auth.Migrations
{
    public partial class fileMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserIconId",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Icon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icon", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserIconId",
                table: "Accounts",
                column: "UserIconId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Icon_UserIconId",
                table: "Accounts",
                column: "UserIconId",
                principalTable: "Icon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Icon_UserIconId",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "Icon");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_UserIconId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "UserIconId",
                table: "Accounts");
        }
    }
}
