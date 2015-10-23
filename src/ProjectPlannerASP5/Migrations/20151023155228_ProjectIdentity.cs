using Microsoft.Data.Entity.Migrations;

namespace ProjectPlannerASP5.Migrations
{
    public partial class ProjectIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Creator", table: "Project");
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Project",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Project_AppUser_CreatorId",
                table: "Project",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Project_AppUser_CreatorId", table: "Project");
            migrationBuilder.DropColumn(name: "CreatorId", table: "Project");
            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "Project",
                nullable: true);
        }
    }
}
