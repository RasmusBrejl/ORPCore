using Microsoft.EntityFrameworkCore.Migrations;

namespace ORPCore.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Cities_CityOneCityId",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Cities_CityTwoCityId",
                table: "Connections");

            migrationBuilder.DropIndex(
                name: "IX_Connections_CityOneCityId",
                table: "Connections");

            migrationBuilder.DropIndex(
                name: "IX_Connections_CityTwoCityId",
                table: "Connections");

            migrationBuilder.DropColumn(
                name: "CityOneCityId",
                table: "Connections");

            migrationBuilder.DropColumn(
                name: "CityTwoCityId",
                table: "Connections");

            migrationBuilder.AddColumn<string>(
                name: "CityOne",
                table: "Connections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityTwo",
                table: "Connections",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityOne",
                table: "Connections");

            migrationBuilder.DropColumn(
                name: "CityTwo",
                table: "Connections");

            migrationBuilder.AddColumn<int>(
                name: "CityOneCityId",
                table: "Connections",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityTwoCityId",
                table: "Connections",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Connections_CityOneCityId",
                table: "Connections",
                column: "CityOneCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_CityTwoCityId",
                table: "Connections",
                column: "CityTwoCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_Cities_CityOneCityId",
                table: "Connections",
                column: "CityOneCityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_Cities_CityTwoCityId",
                table: "Connections",
                column: "CityTwoCityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
