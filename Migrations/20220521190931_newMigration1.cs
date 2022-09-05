using Microsoft.EntityFrameworkCore.Migrations;

namespace Diplom.Auth.Migrations
{
    public partial class newMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "UserTasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "UserReferences",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_AccountId",
                table: "UserTasks",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReferences_AccountId",
                table: "UserReferences",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReferences_Accounts_AccountId",
                table: "UserReferences",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_Accounts_AccountId",
                table: "UserTasks",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserReferences_Accounts_AccountId",
                table: "UserReferences");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_Accounts_AccountId",
                table: "UserTasks");

            migrationBuilder.DropIndex(
                name: "IX_UserTasks_AccountId",
                table: "UserTasks");

            migrationBuilder.DropIndex(
                name: "IX_UserReferences_AccountId",
                table: "UserReferences");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "UserReferences");
        }
    }
}
