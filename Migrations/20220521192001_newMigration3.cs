using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diplom.Auth.Migrations
{
    public partial class newMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "ChatRooms");

            migrationBuilder.AddColumn<int>(
                name: "ChatRoomId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatingChatDataId",
                table: "ChatRooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CreatingChatData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatingChatData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreatingChatData_Accounts_UserCreateId",
                        column: x => x.UserCreateId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatRoomId",
                table: "Messages",
                column: "ChatRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRooms_CreatingChatDataId",
                table: "ChatRooms",
                column: "CreatingChatDataId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatingChatData_UserCreateId",
                table: "CreatingChatData",
                column: "UserCreateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_CreatingChatData_CreatingChatDataId",
                table: "ChatRooms",
                column: "CreatingChatDataId",
                principalTable: "CreatingChatData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatRooms_ChatRoomId",
                table: "Messages",
                column: "ChatRoomId",
                principalTable: "ChatRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRooms_CreatingChatData_CreatingChatDataId",
                table: "ChatRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatRooms_ChatRoomId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "CreatingChatData");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ChatRoomId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_ChatRooms_CreatingChatDataId",
                table: "ChatRooms");

            migrationBuilder.DropColumn(
                name: "ChatRoomId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "CreatingChatDataId",
                table: "ChatRooms");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "ChatRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
