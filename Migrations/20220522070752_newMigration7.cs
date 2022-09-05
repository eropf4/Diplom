using Microsoft.EntityFrameworkCore.Migrations;

namespace Diplom.Auth.Migrations
{
    public partial class newMigration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkgroupTask_Workgroups_WorkgroupId",
                table: "WorkgroupTask");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkgroupTask_WorkgroupTaskStatus_WorkgroupTaskStatusId",
                table: "WorkgroupTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkgroupTaskStatus",
                table: "WorkgroupTaskStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkgroupTask",
                table: "WorkgroupTask");

            migrationBuilder.RenameTable(
                name: "WorkgroupTaskStatus",
                newName: "WorkgroupTaskStatuses");

            migrationBuilder.RenameTable(
                name: "WorkgroupTask",
                newName: "WorkgroupTasks");

            migrationBuilder.RenameIndex(
                name: "IX_WorkgroupTask_WorkgroupTaskStatusId",
                table: "WorkgroupTasks",
                newName: "IX_WorkgroupTasks_WorkgroupTaskStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkgroupTask_WorkgroupId",
                table: "WorkgroupTasks",
                newName: "IX_WorkgroupTasks_WorkgroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkgroupTaskStatuses",
                table: "WorkgroupTaskStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkgroupTasks",
                table: "WorkgroupTasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkgroupTasks_Workgroups_WorkgroupId",
                table: "WorkgroupTasks",
                column: "WorkgroupId",
                principalTable: "Workgroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkgroupTasks_WorkgroupTaskStatuses_WorkgroupTaskStatusId",
                table: "WorkgroupTasks",
                column: "WorkgroupTaskStatusId",
                principalTable: "WorkgroupTaskStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkgroupTasks_Workgroups_WorkgroupId",
                table: "WorkgroupTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkgroupTasks_WorkgroupTaskStatuses_WorkgroupTaskStatusId",
                table: "WorkgroupTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkgroupTaskStatuses",
                table: "WorkgroupTaskStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkgroupTasks",
                table: "WorkgroupTasks");

            migrationBuilder.RenameTable(
                name: "WorkgroupTaskStatuses",
                newName: "WorkgroupTaskStatus");

            migrationBuilder.RenameTable(
                name: "WorkgroupTasks",
                newName: "WorkgroupTask");

            migrationBuilder.RenameIndex(
                name: "IX_WorkgroupTasks_WorkgroupTaskStatusId",
                table: "WorkgroupTask",
                newName: "IX_WorkgroupTask_WorkgroupTaskStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkgroupTasks_WorkgroupId",
                table: "WorkgroupTask",
                newName: "IX_WorkgroupTask_WorkgroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkgroupTaskStatus",
                table: "WorkgroupTaskStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkgroupTask",
                table: "WorkgroupTask",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkgroupTask_Workgroups_WorkgroupId",
                table: "WorkgroupTask",
                column: "WorkgroupId",
                principalTable: "Workgroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkgroupTask_WorkgroupTaskStatus_WorkgroupTaskStatusId",
                table: "WorkgroupTask",
                column: "WorkgroupTaskStatusId",
                principalTable: "WorkgroupTaskStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
