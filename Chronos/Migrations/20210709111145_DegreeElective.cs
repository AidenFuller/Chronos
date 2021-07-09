using Microsoft.EntityFrameworkCore.Migrations;

namespace Chronos.Migrations
{
    public partial class DegreeElective : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ElectiveCount",
                table: "Degrees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ElectiveCount",
                table: "Degrees");
        }
    }
}
