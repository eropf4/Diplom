using Microsoft.EntityFrameworkCore.Migrations;

namespace Diplom.Auth.Migrations
{
    public partial class userTasksWorkgroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkgroupTaskId",
                table: "UserTasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_WorkgroupTaskId",
                table: "UserTasks",
                column: "WorkgroupTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_WorkgroupTasks_WorkgroupTaskId",
                table: "UserTasks",
                column: "WorkgroupTaskId",
                principalTable: "WorkgroupTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_WorkgroupTasks_WorkgroupTaskId",
                table: "UserTasks");

            migrationBuilder.DropIndex(
                name: "IX_UserTasks_WorkgroupTaskId",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "WorkgroupTaskId",
                table: "UserTasks");
        }
    }
}
