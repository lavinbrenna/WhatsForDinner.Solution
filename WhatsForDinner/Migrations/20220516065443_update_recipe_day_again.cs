using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsForDinner.Migrations
{
    public partial class update_recipe_day_again : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreakfastRecipes_RecipeDays_RecipeDayId",
                table: "BreakfastRecipes");

            migrationBuilder.DropForeignKey(
                name: "FK_DinnerRecipes_RecipeDays_RecipeDayId",
                table: "DinnerRecipes");

            migrationBuilder.DropForeignKey(
                name: "FK_LunchRecipes_RecipeDays_RecipeDayId",
                table: "LunchRecipes");

            migrationBuilder.DropIndex(
                name: "IX_LunchRecipes_RecipeDayId",
                table: "LunchRecipes");

            migrationBuilder.DropIndex(
                name: "IX_DinnerRecipes_RecipeDayId",
                table: "DinnerRecipes");

            migrationBuilder.DropIndex(
                name: "IX_BreakfastRecipes_RecipeDayId",
                table: "BreakfastRecipes");

            migrationBuilder.DropColumn(
                name: "RecipeDayId",
                table: "LunchRecipes");

            migrationBuilder.DropColumn(
                name: "RecipeDayId",
                table: "DinnerRecipes");

            migrationBuilder.DropColumn(
                name: "RecipeDayId",
                table: "BreakfastRecipes");

            migrationBuilder.AddColumn<int>(
                name: "BreakfastRecipeId",
                table: "RecipeDays",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DinnerRecipeId",
                table: "RecipeDays",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LunchRecipeId",
                table: "RecipeDays",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDays_BreakfastRecipeId",
                table: "RecipeDays",
                column: "BreakfastRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDays_DinnerRecipeId",
                table: "RecipeDays",
                column: "DinnerRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDays_LunchRecipeId",
                table: "RecipeDays",
                column: "LunchRecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeDays_Recipes_BreakfastRecipeId",
                table: "RecipeDays",
                column: "BreakfastRecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeDays_Recipes_DinnerRecipeId",
                table: "RecipeDays",
                column: "DinnerRecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeDays_Recipes_LunchRecipeId",
                table: "RecipeDays",
                column: "LunchRecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeDays_Recipes_BreakfastRecipeId",
                table: "RecipeDays");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeDays_Recipes_DinnerRecipeId",
                table: "RecipeDays");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeDays_Recipes_LunchRecipeId",
                table: "RecipeDays");

            migrationBuilder.DropIndex(
                name: "IX_RecipeDays_BreakfastRecipeId",
                table: "RecipeDays");

            migrationBuilder.DropIndex(
                name: "IX_RecipeDays_DinnerRecipeId",
                table: "RecipeDays");

            migrationBuilder.DropIndex(
                name: "IX_RecipeDays_LunchRecipeId",
                table: "RecipeDays");

            migrationBuilder.DropColumn(
                name: "BreakfastRecipeId",
                table: "RecipeDays");

            migrationBuilder.DropColumn(
                name: "DinnerRecipeId",
                table: "RecipeDays");

            migrationBuilder.DropColumn(
                name: "LunchRecipeId",
                table: "RecipeDays");

            migrationBuilder.AddColumn<int>(
                name: "RecipeDayId",
                table: "LunchRecipes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeDayId",
                table: "DinnerRecipes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeDayId",
                table: "BreakfastRecipes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LunchRecipes_RecipeDayId",
                table: "LunchRecipes",
                column: "RecipeDayId");

            migrationBuilder.CreateIndex(
                name: "IX_DinnerRecipes_RecipeDayId",
                table: "DinnerRecipes",
                column: "RecipeDayId");

            migrationBuilder.CreateIndex(
                name: "IX_BreakfastRecipes_RecipeDayId",
                table: "BreakfastRecipes",
                column: "RecipeDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_BreakfastRecipes_RecipeDays_RecipeDayId",
                table: "BreakfastRecipes",
                column: "RecipeDayId",
                principalTable: "RecipeDays",
                principalColumn: "RecipeDayId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DinnerRecipes_RecipeDays_RecipeDayId",
                table: "DinnerRecipes",
                column: "RecipeDayId",
                principalTable: "RecipeDays",
                principalColumn: "RecipeDayId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LunchRecipes_RecipeDays_RecipeDayId",
                table: "LunchRecipes",
                column: "RecipeDayId",
                principalTable: "RecipeDays",
                principalColumn: "RecipeDayId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
