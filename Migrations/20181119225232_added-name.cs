using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkPlanner.Migrations
{
    public partial class addedname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Plans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Plans");
        }
    }
}
