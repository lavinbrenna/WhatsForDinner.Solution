using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsForDinner.Migrations
{
    public partial class remove_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeDays_Days_DayId",
                table: "RecipeDays");

            migrationBuilder.DropTable(
                name: "BreakfastRecipes");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "DinnerRecipes");

            migrationBuilder.DropTable(
                name: "LunchRecipes");

            migrationBuilder.DropIndex(
                name: "IX_RecipeDays_DayId",
                table: "RecipeDays");

            migrationBuilder.DropColumn(
                name: "DayId",
                table: "RecipeDays");

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

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "RecipeDays",
                type: "varchar(255) CHARACTER SET utf8mb4",
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

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDays_UserId",
                table: "RecipeDays",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeDays_AspNetUsers_UserId",
                table: "RecipeDays",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_RecipeDays_AspNetUsers_UserId",
                table: "RecipeDays");

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

            migrationBuilder.DropIndex(
                name: "IX_RecipeDays_UserId",
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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RecipeDays");

            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "RecipeDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BreakfastRecipes",
                columns: table => new
                {
                    BreakfastRecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakfastRecipes", x => x.BreakfastRecipeId);
                    table.ForeignKey(
                        name: "FK_BreakfastRecipes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BreakfastRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    DayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BreakfastRecipeRecipeId = table.Column<int>(type: "int", nullable: true),
                    DinnerRecipeRecipeId = table.Column<int>(type: "int", nullable: true),
                    LunchRecipeRecipeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.DayId);
                    table.ForeignKey(
                        name: "FK_Days_Recipes_BreakfastRecipeRecipeId",
                        column: x => x.BreakfastRecipeRecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Days_Recipes_DinnerRecipeRecipeId",
                        column: x => x.DinnerRecipeRecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Days_Recipes_LunchRecipeRecipeId",
                        column: x => x.LunchRecipeRecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DinnerRecipes",
                columns: table => new
                {
                    DinnerRecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DinnerRecipes", x => x.DinnerRecipeId);
                    table.ForeignKey(
                        name: "FK_DinnerRecipes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
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
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LunchRecipes", x => x.LunchRecipeId);
                    table.ForeignKey(
                        name: "FK_LunchRecipes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LunchRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDays_DayId",
                table: "RecipeDays",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_BreakfastRecipes_RecipeId",
                table: "BreakfastRecipes",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_BreakfastRecipes_UserId",
                table: "BreakfastRecipes",
                column: "UserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_DinnerRecipes_RecipeId",
                table: "DinnerRecipes",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_DinnerRecipes_UserId",
                table: "DinnerRecipes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LunchRecipes_RecipeId",
                table: "LunchRecipes",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_LunchRecipes_UserId",
                table: "LunchRecipes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeDays_Days_DayId",
                table: "RecipeDays",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "DayId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
