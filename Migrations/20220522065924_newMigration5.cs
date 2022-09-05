using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diplom.Auth.Migrations
{
    public partial class newMigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkgroupStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    defifnition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkgroupStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workgroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDataTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripton = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkgroupStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workgroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workgroups_WorkgroupStatuses_WorkgroupStatusId",
                        column: x => x.WorkgroupStatusId,
                        principalTable: "WorkgroupStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountWorkgroup",
                columns: table => new
                {
                    WorkgroupsId = table.Column<int>(type: "int", nullable: false),
                    WorkingUsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountWorkgroup", x => new { x.WorkgroupsId, x.WorkingUsersId });
                    table.ForeignKey(
                        name: "FK_AccountWorkgroup_Accounts_WorkingUsersId",
                        column: x => x.WorkingUsersId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountWorkgroup_Workgroups_WorkgroupsId",
                        column: x => x.WorkgroupsId,
                        principalTable: "Workgroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountWorkgroup_WorkingUsersId",
                table: "AccountWorkgroup",
                column: "WorkingUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Workgroups_WorkgroupStatusId",
                table: "Workgroups",
                column: "WorkgroupStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountWorkgroup");

            migrationBuilder.DropTable(
                name: "Workgroups");

            migrationBuilder.DropTable(
                name: "WorkgroupStatuses");
        }
    }
}
