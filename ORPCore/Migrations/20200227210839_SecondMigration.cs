using Microsoft.EntityFrameworkCore.Migrations;

namespace ORPCore.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "PricePenalty",
                table: "Cities",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "Valid",
                table: "Cities",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePenalty",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "Valid",
                table: "Cities");
        }
    }
}
