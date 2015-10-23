using Microsoft.Data.Entity.Migrations;

namespace ProjectPlannerASP5.Migrations
{
    public partial class ProjectNameCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Project",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Project",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Project",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Project",
                nullable: true);
        }
    }
}
