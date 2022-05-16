using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsForDinner.Migrations
{
    public partial class update_day : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreakfastRecipes_BreakfastRecipes_BreakfastRecipeId1",
                table: "BreakfastRecipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_BreakfastRecipes_BreakfastRecipeId",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_DinnerRecipes_DinnerRecipeId",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_LunchRecipes_LunchRecipeId",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_DinnerRecipes_DinnerRecipes_DinnerRecipeId1",
                table: "DinnerRecipes");

            migrationBuilder.DropForeignKey(
                name: "FK_LunchRecipes_LunchRecipes_LunchRecipeId1",
                table: "LunchRecipes");

            migrationBuilder.DropIndex(
                name: "IX_LunchRecipes_LunchRecipeId1",
                table: "LunchRecipes");

            migrationBuilder.DropIndex(
                name: "IX_DinnerRecipes_DinnerRecipeId1",
                table: "DinnerRecipes");

            migrationBuilder.DropIndex(
                name: "IX_Days_BreakfastRecipeId",
                table: "Days");

            migrationBuilder.DropIndex(
                name: "IX_Days_DinnerRecipeId",
                table: "Days");

            migrationBuilder.DropIndex(
                name: "IX_Days_LunchRecipeId",
                table: "Days");

            migrationBuilder.DropIndex(
                name: "IX_BreakfastRecipes_BreakfastRecipeId1",
                table: "BreakfastRecipes");

            migrationBuilder.DropColumn(
                name: "LunchRecipeId1",
                table: "LunchRecipes");

            migrationBuilder.DropColumn(
                name: "DinnerRecipeId1",
                table: "DinnerRecipes");

            migrationBuilder.DropColumn(
                name: "BreakfastRecipeId",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "DinnerRecipeId",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "LunchRecipeId",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "BreakfastRecipeId1",
                table: "BreakfastRecipes");

            migrationBuilder.AddColumn<int>(
                name: "BreakfastRecipeRecipeId",
                table: "Days",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DinnerRecipeRecipeId",
                table: "Days",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LunchRecipeRecipeId",
                table: "Days",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Days_BreakfastRecipeRecipeId",
                table: "Days",
                column: "BreakfastRecipeRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_DinnerRecipeRecipeId",
                table: "Days",
                column: "DinnerRecipeRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_LunchRecipeRecipeId",
                table: "Days",
                column: "LunchRecipeRecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Recipes_BreakfastRecipeRecipeId",
                table: "Days",
                column: "BreakfastRecipeRecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Recipes_DinnerRecipeRecipeId",
                table: "Days",
                column: "DinnerRecipeRecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Recipes_LunchRecipeRecipeId",
                table: "Days",
                column: "LunchRecipeRecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Recipes_BreakfastRecipeRecipeId",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_Recipes_DinnerRecipeRecipeId",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_Recipes_LunchRecipeRecipeId",
                table: "Days");

            migrationBuilder.DropIndex(
                name: "IX_Days_BreakfastRecipeRecipeId",
                table: "Days");

            migrationBuilder.DropIndex(
                name: "IX_Days_DinnerRecipeRecipeId",
                table: "Days");

            migrationBuilder.DropIndex(
                name: "IX_Days_LunchRecipeRecipeId",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "BreakfastRecipeRecipeId",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "DinnerRecipeRecipeId",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "LunchRecipeRecipeId",
                table: "Days");

            migrationBuilder.AddColumn<int>(
                name: "LunchRecipeId1",
                table: "LunchRecipes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DinnerRecipeId1",
                table: "DinnerRecipes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BreakfastRecipeId",
                table: "Days",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DinnerRecipeId",
                table: "Days",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LunchRecipeId",
                table: "Days",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BreakfastRecipeId1",
                table: "BreakfastRecipes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LunchRecipes_LunchRecipeId1",
                table: "LunchRecipes",
                column: "LunchRecipeId1");

            migrationBuilder.CreateIndex(
                name: "IX_DinnerRecipes_DinnerRecipeId1",
                table: "DinnerRecipes",
                column: "DinnerRecipeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Days_BreakfastRecipeId",
                table: "Days",
                column: "BreakfastRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_DinnerRecipeId",
                table: "Days",
                column: "DinnerRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_LunchRecipeId",
                table: "Days",
                column: "LunchRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_BreakfastRecipes_BreakfastRecipeId1",
                table: "BreakfastRecipes",
                column: "BreakfastRecipeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BreakfastRecipes_BreakfastRecipes_BreakfastRecipeId1",
                table: "BreakfastRecipes",
                column: "BreakfastRecipeId1",
                principalTable: "BreakfastRecipes",
                principalColumn: "BreakfastRecipeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_BreakfastRecipes_BreakfastRecipeId",
                table: "Days",
                column: "BreakfastRecipeId",
                principalTable: "BreakfastRecipes",
                principalColumn: "BreakfastRecipeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_DinnerRecipes_DinnerRecipeId",
                table: "Days",
                column: "DinnerRecipeId",
                principalTable: "DinnerRecipes",
                principalColumn: "DinnerRecipeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_LunchRecipes_LunchRecipeId",
                table: "Days",
                column: "LunchRecipeId",
                principalTable: "LunchRecipes",
                principalColumn: "LunchRecipeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DinnerRecipes_DinnerRecipes_DinnerRecipeId1",
                table: "DinnerRecipes",
                column: "DinnerRecipeId1",
                principalTable: "DinnerRecipes",
                principalColumn: "DinnerRecipeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LunchRecipes_LunchRecipes_LunchRecipeId1",
                table: "LunchRecipes",
                column: "LunchRecipeId1",
                principalTable: "LunchRecipes",
                principalColumn: "LunchRecipeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
