using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsForDinner.Migrations
{
    public partial class re_add_meal_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "BreakfastRecipes",
                columns: table => new
                {
                    BreakfastRecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    RecipeDayId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakfastRecipes", x => x.BreakfastRecipeId);
                    table.ForeignKey(
                        name: "FK_BreakfastRecipes_RecipeDays_RecipeDayId",
                        column: x => x.RecipeDayId,
                        principalTable: "RecipeDays",
                        principalColumn: "RecipeDayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BreakfastRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DinnerRecipes",
                columns: table => new
                {
                    DinnerRecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    RecipeDayId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DinnerRecipes", x => x.DinnerRecipeId);
                    table.ForeignKey(
                        name: "FK_DinnerRecipes_RecipeDays_RecipeDayId",
                        column: x => x.RecipeDayId,
                        principalTable: "RecipeDays",
                        principalColumn: "RecipeDayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DinnerRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LunchRecipes",
                columns: table => new
                {
                    LunchRecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    RecipeDayId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LunchRecipes", x => x.LunchRecipeId);
                    table.ForeignKey(
                        name: "FK_LunchRecipes_RecipeDays_RecipeDayId",
                        column: x => x.RecipeDayId,
                        principalTable: "RecipeDays",
                        principalColumn: "RecipeDayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LunchRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BreakfastRecipes_RecipeDayId",
                table: "BreakfastRecipes",
                column: "RecipeDayId");

            migrationBuilder.CreateIndex(
                name: "IX_BreakfastRecipes_RecipeId",
                table: "BreakfastRecipes",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_DinnerRecipes_RecipeDayId",
                table: "DinnerRecipes",
                column: "RecipeDayId");

            migrationBuilder.CreateIndex(
                name: "IX_DinnerRecipes_RecipeId",
                table: "DinnerRecipes",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_LunchRecipes_RecipeDayId",
                table: "LunchRecipes",
                column: "RecipeDayId");

            migrationBuilder.CreateIndex(
                name: "IX_LunchRecipes_RecipeId",
                table: "LunchRecipes",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreakfastRecipes");

            migrationBuilder.DropTable(
                name: "DinnerRecipes");

            migrationBuilder.DropTable(
                name: "LunchRecipes");

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
    }
}
