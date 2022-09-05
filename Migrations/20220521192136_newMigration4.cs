using Microsoft.EntityFrameworkCore.Migrations;

namespace Diplom.Auth.Migrations
{
    public partial class newMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRooms_CreatingChatData_CreatingChatDataId",
                table: "ChatRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_CreatingChatData_Accounts_UserCreateId",
                table: "CreatingChatData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreatingChatData",
                table: "CreatingChatData");

            migrationBuilder.RenameTable(
                name: "CreatingChatData",
                newName: "CreatingChatDatas");

            migrationBuilder.RenameIndex(
                name: "IX_CreatingChatData_UserCreateId",
                table: "CreatingChatDatas",
                newName: "IX_CreatingChatDatas_UserCreateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreatingChatDatas",
                table: "CreatingChatDatas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_CreatingChatDatas_CreatingChatDataId",
                table: "ChatRooms",
                column: "CreatingChatDataId",
                principalTable: "CreatingChatDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CreatingChatDatas_Accounts_UserCreateId",
                table: "CreatingChatDatas",
                column: "UserCreateId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRooms_CreatingChatDatas_CreatingChatDataId",
                table: "ChatRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_CreatingChatDatas_Accounts_UserCreateId",
                table: "CreatingChatDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreatingChatDatas",
                table: "CreatingChatDatas");

            migrationBuilder.RenameTable(
                name: "CreatingChatDatas",
                newName: "CreatingChatData");

            migrationBuilder.RenameIndex(
                name: "IX_CreatingChatDatas_UserCreateId",
                table: "CreatingChatData",
                newName: "IX_CreatingChatData_UserCreateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreatingChatData",
                table: "CreatingChatData",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_CreatingChatData_CreatingChatDataId",
                table: "ChatRooms",
                column: "CreatingChatDataId",
                principalTable: "CreatingChatData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CreatingChatData_Accounts_UserCreateId",
                table: "CreatingChatData",
                column: "UserCreateId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
