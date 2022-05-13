using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsForDinner.Migrations
{
    public partial class update_application_user_recipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserRecipes_Recipes_RecipeId",
                table: "ApplicationUserRecipes");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "ApplicationUserRecipes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRecipes_Recipes_RecipeId",
                table: "ApplicationUserRecipes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserRecipes_Recipes_RecipeId",
                table: "ApplicationUserRecipes");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "ApplicationUserRecipes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRecipes_Recipes_RecipeId",
                table: "ApplicationUserRecipes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
