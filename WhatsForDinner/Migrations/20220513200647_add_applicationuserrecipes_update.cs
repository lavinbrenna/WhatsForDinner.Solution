using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsForDinner.Migrations
{
    public partial class add_applicationuserrecipes_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_UserCalendars_UserCalendarId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "UserCalendars");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_UserCalendarId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "UserCalendarId",
                table: "Recipes");

            migrationBuilder.CreateTable(
                name: "ApplicationUserRecipes",
                columns: table => new
                {
                    ApplicationUserRecipesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserRecipesRecipe",
                columns: table => new
                {
                    JoinEntitiesApplicationUserRecipesId = table.Column<int>(type: "int", nullable: false),
                    RecipesRecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserRecipesRecipe", x => new { x.JoinEntitiesApplicationUserRecipesId, x.RecipesRecipeId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserRecipesRecipe_ApplicationUserRecipes_JoinEnti~",
                        column: x => x.JoinEntitiesApplicationUserRecipesId,
                        principalTable: "ApplicationUserRecipes",
                        principalColumn: "ApplicationUserRecipesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserRecipesRecipe_Recipes_RecipesRecipeId",
                        column: x => x.RecipesRecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRecipes_ApplicationUserId",
                table: "ApplicationUserRecipes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRecipesRecipe_RecipesRecipeId",
                table: "ApplicationUserRecipesRecipe",
                column: "RecipesRecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserRecipesRecipe");

            migrationBuilder.DropTable(
                name: "ApplicationUserRecipes");

            migrationBuilder.AddColumn<int>(
                name: "UserCalendarId",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserCalendars",
                columns: table => new
                {
                    UserCalendarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCalendars", x => x.UserCalendarId);
                    table.ForeignKey(
                        name: "FK_UserCalendars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserCalendarId",
                table: "Recipes",
                column: "UserCalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCalendars_UserId",
                table: "UserCalendars",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_UserCalendars_UserCalendarId",
                table: "Recipes",
                column: "UserCalendarId",
                principalTable: "UserCalendars",
                principalColumn: "UserCalendarId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
