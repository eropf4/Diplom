using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diplom.Auth.Migrations
{
    public partial class newMigration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Projects_ProjectId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Accounts_CreatorId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_CreatorId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_ProjectId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "defifnition",
                table: "WorkgroupStatuses",
                newName: "Defifnition");

            migrationBuilder.CreateTable(
                name: "AccountProject",
                columns: table => new
                {
                    ProjectUsersId = table.Column<int>(type: "int", nullable: false),
                    ProjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountProject", x => new { x.ProjectUsersId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_AccountProject_Accounts_ProjectUsersId",
                        column: x => x.ProjectUsersId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountProject_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkgroupTaskStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Readiness = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkgroupTaskStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkgroupTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeginDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkgroupTaskStatusId = table.Column<int>(type: "int", nullable: true),
                    WorkgroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkgroupTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkgroupTask_Workgroups_WorkgroupId",
                        column: x => x.WorkgroupId,
                        principalTable: "Workgroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkgroupTask_WorkgroupTaskStatus_WorkgroupTaskStatusId",
                        column: x => x.WorkgroupTaskStatusId,
                        principalTable: "WorkgroupTaskStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountProject_ProjectsId",
                table: "AccountProject",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkgroupTask_WorkgroupId",
                table: "WorkgroupTask",
                column: "WorkgroupId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkgroupTask_WorkgroupTaskStatusId",
                table: "WorkgroupTask",
                column: "WorkgroupTaskStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountProject");

            migrationBuilder.DropTable(
                name: "WorkgroupTask");

            migrationBuilder.DropTable(
                name: "WorkgroupTaskStatus");

            migrationBuilder.RenameColumn(
                name: "Defifnition",
                table: "WorkgroupStatuses",
                newName: "defifnition");

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CreatorId",
                table: "Projects",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ProjectId",
                table: "Accounts",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Projects_ProjectId",
                table: "Accounts",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Accounts_CreatorId",
                table: "Projects",
                column: "CreatorId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
