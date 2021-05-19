using Microsoft.EntityFrameworkCore.Migrations;

namespace People.Migrations
{
    public partial class AddedCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityPerson");

            migrationBuilder.DropColumn(
                name: "City",
                table: "persons");

            migrationBuilder.AddColumn<int>(
                name: "InCityId",
                table: "persons",
                type: "int",
                maxLength: 70,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_persons_InCityId",
                table: "persons",
                column: "InCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_persons_Towns_InCityId",
                table: "persons",
                column: "InCityId",
                principalTable: "Towns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_persons_Towns_InCityId",
                table: "persons");

            migrationBuilder.DropIndex(
                name: "IX_persons_InCityId",
                table: "persons");

            migrationBuilder.DropColumn(
                name: "InCityId",
                table: "persons");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "persons",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CityPerson",
                columns: table => new
                {
                    CityIdId = table.Column<int>(type: "int", nullable: false),
                    townresidentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityPerson", x => new { x.CityIdId, x.townresidentId });
                    table.ForeignKey(
                        name: "FK_CityPerson_persons_townresidentId",
                        column: x => x.townresidentId,
                        principalTable: "persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityPerson_Towns_CityIdId",
                        column: x => x.CityIdId,
                        principalTable: "Towns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityPerson_townresidentId",
                table: "CityPerson",
                column: "townresidentId");
        }
    }
}
