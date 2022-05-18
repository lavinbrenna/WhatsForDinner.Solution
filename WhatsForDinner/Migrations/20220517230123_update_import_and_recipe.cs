using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsForDinner.Migrations
{
    public partial class update_import_and_recipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxFrequency",
                table: "Recipes");

            migrationBuilder.AddColumn<string>(
                name: "SourceImgUrl",
                table: "Recipes",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinFrequency",
                table: "ImportedRecipes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SourceImgUrl",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "MinFrequency",
                table: "ImportedRecipes");

            migrationBuilder.AddColumn<int>(
                name: "MaxFrequency",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
