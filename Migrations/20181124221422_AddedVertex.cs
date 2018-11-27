using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkPlanner.Migrations
{
    public partial class AddedVertex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LatLng_Cell_CellId",
                table: "LatLng");

            migrationBuilder.DropIndex(
                name: "IX_LatLng_CellId",
                table: "LatLng");

            migrationBuilder.DropColumn(
                name: "CellId",
                table: "LatLng");

            migrationBuilder.CreateTable(
                name: "Vertex",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CellId = table.Column<int>(nullable: true),
                    Position = table.Column<int>(nullable: true),
                    LatLngId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vertex", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vertex_Cell_CellId",
                        column: x => x.CellId,
                        principalTable: "Cell",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vertex_LatLng_LatLngId",
                        column: x => x.LatLngId,
                        principalTable: "LatLng",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vertex_CellId",
                table: "Vertex",
                column: "CellId");

            migrationBuilder.CreateIndex(
                name: "IX_Vertex_LatLngId",
                table: "Vertex",
                column: "LatLngId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vertex");

            migrationBuilder.AddColumn<int>(
                name: "CellId",
                table: "LatLng",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LatLng_CellId",
                table: "LatLng",
                column: "CellId");

            migrationBuilder.AddForeignKey(
                name: "FK_LatLng_Cell_CellId",
                table: "LatLng",
                column: "CellId",
                principalTable: "Cell",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
