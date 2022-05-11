using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsForDinner.Migrations
{
    public partial class update_recipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Breakfast",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Dinner",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Lunch",
                table: "Recipes");

            migrationBuilder.AddColumn<bool>(
                name: "isBreakfast",
                table: "Recipes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDinner",
                table: "Recipes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isLunch",
                table: "Recipes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isBreakfast",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "isDinner",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "isLunch",
                table: "Recipes");

            migrationBuilder.AddColumn<string>(
                name: "Breakfast",
                table: "Recipes",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dinner",
                table: "Recipes",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lunch",
                table: "Recipes",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
