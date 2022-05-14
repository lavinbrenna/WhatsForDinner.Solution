using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsForDinner.Migrations
{
    public partial class update_recipe_again : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipeDate",
                table: "RecipeDays");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "RecipeDays",
                newName: "DayName");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId1",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeId1",
                table: "Recipes",
                column: "RecipeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Recipes_RecipeId1",
                table: "Recipes",
                column: "RecipeId1",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Recipes_RecipeId1",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_RecipeId1",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeId1",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "DayName",
                table: "RecipeDays",
                newName: "Name");

            migrationBuilder.AddColumn<DateTime>(
                name: "RecipeDate",
                table: "RecipeDays",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
