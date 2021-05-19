using Microsoft.EntityFrameworkCore.Migrations;

namespace People.Migrations
{
    public partial class AddedNyTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_persons_Towns_InCityId",
                table: "persons");

            migrationBuilder.AlterColumn<int>(
                name: "InCityId",
                table: "persons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 70);

            migrationBuilder.AddForeignKey(
                name: "FK_persons_Towns_InCityId",
                table: "persons",
                column: "InCityId",
                principalTable: "Towns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_persons_Towns_InCityId",
                table: "persons");

            migrationBuilder.AlterColumn<int>(
                name: "InCityId",
                table: "persons",
                type: "int",
                maxLength: 70,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_persons_Towns_InCityId",
                table: "persons",
                column: "InCityId",
                principalTable: "Towns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
