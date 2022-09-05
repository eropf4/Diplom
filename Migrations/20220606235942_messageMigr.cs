using Microsoft.EntityFrameworkCore.Migrations;

namespace Diplom.Auth.Migrations
{
    public partial class messageMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "messageCreatorId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_messageCreatorId",
                table: "Messages",
                column: "messageCreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Accounts_messageCreatorId",
                table: "Messages",
                column: "messageCreatorId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Accounts_messageCreatorId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_messageCreatorId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "messageCreatorId",
                table: "Messages");
        }
    }
}
