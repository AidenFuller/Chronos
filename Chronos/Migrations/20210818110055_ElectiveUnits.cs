using Microsoft.EntityFrameworkCore.Migrations;

namespace Chronos.Migrations
{
    public partial class ElectiveUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ElectiveCount",
                table: "Degrees",
                newName: "ElectiveUnits");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ElectiveUnits",
                table: "Degrees",
                newName: "ElectiveCount");
        }
    }
}
