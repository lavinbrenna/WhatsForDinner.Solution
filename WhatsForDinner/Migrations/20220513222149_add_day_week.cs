using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsForDinner.Migrations
{
    public partial class add_day_week : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Recipes_RecipeId1",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "ApplicationUserRecipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_RecipeId1",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeId1",
                table: "Recipes");

            migrationBuilder.CreateTable(
                name: "RecipeWeek",
                columns: table => new
                {
                    RecipeWeekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WeekOf = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeWeek", x => x.RecipeWeekId);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserWeek",
                columns: table => new
                {
                    ApplicationUserWeekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    RecipeWeekId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserWeek", x => x.ApplicationUserWeekId);
                    table.ForeignKey(
                        name: "FK_ApplicationUserWeek_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationUserWeek_RecipeWeek_RecipeWeekId",
                        column: x => x.RecipeWeekId,
                        principalTable: "RecipeWeek",
                        principalColumn: "RecipeWeekId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeDays",
                columns: table => new
                {
                    RecipeDayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    RecipeDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BreakfastRecipeId = table.Column<int>(type: "int", nullable: true),
                    LunchRecipeId = table.Column<int>(type: "int", nullable: true),
                    DinnerRecipeId = table.Column<int>(type: "int", nullable: true),
                    RecipeWeekId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDays", x => x.RecipeDayId);
                    table.ForeignKey(
                        name: "FK_RecipeDays_Recipes_BreakfastRecipeId",
                        column: x => x.BreakfastRecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeDays_Recipes_DinnerRecipeId",
                        column: x => x.DinnerRecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeDays_Recipes_LunchRecipeId",
                        column: x => x.LunchRecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeDays_RecipeWeek_RecipeWeekId",
                        column: x => x.RecipeWeekId,
                        principalTable: "RecipeWeek",
                        principalColumn: "RecipeWeekId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserWeek_ApplicationUserId",
                table: "ApplicationUserWeek",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserWeek_RecipeWeekId",
                table: "ApplicationUserWeek",
                column: "RecipeWeekId");

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

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDays_RecipeWeekId",
                table: "RecipeDays",
                column: "RecipeWeekId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserWeek");

            migrationBuilder.DropTable(
                name: "RecipeDays");

            migrationBuilder.DropTable(
                name: "RecipeWeek");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId1",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUserRecipes",
                columns: table => new
                {
                    ApplicationUserRecipesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    RecipeId = table.Column<int>(type: "int", nullable: true),
                    RecipeList = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserRecipes", x => x.ApplicationUserRecipesId);
                    table.ForeignKey(
                        name: "FK_ApplicationUserRecipes_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationUserRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeId1",
                table: "Recipes",
                column: "RecipeId1");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRecipes_ApplicationUserId",
                table: "ApplicationUserRecipes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRecipes_RecipeId",
                table: "ApplicationUserRecipes",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Recipes_RecipeId1",
                table: "Recipes",
                column: "RecipeId1",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
