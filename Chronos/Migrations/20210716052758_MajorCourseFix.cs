using Microsoft.EntityFrameworkCore.Migrations;

namespace Chronos.Migrations
{
    public partial class MajorCourseFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCore",
                table: "MajorCourses",
                newName: "IsCompulsory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCompulsory",
                table: "MajorCourses",
                newName: "IsCore");
        }
    }
}
