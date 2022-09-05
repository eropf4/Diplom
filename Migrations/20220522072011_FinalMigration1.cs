using Microsoft.EntityFrameworkCore.Migrations;

namespace Diplom.Auth.Migrations
{
    public partial class FinalMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectWorkgroup",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(type: "int", nullable: false),
                    WorkgroupsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectWorkgroup", x => new { x.ProjectsId, x.WorkgroupsId });
                    table.ForeignKey(
                        name: "FK_ProjectWorkgroup_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectWorkgroup_Workgroups_WorkgroupsId",
                        column: x => x.WorkgroupsId,
                        principalTable: "Workgroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWorkgroup_WorkgroupsId",
                table: "ProjectWorkgroup",
                column: "WorkgroupsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectWorkgroup");
        }
    }
}
