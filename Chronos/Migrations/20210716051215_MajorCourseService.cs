using Microsoft.EntityFrameworkCore.Migrations;

namespace Chronos.Migrations
{
    public partial class MajorCourseService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseRequisite",
                table: "PrerequisiteCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseRequisite",
                table: "PrerequisiteCourses");
        }
    }
}
