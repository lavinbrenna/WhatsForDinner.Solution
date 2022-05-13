using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsForDinner.Migrations
{
    public partial class re_add_applicationUserRecipes : Migration
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
                    RecipeId = table.Column<int>(type: "int", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRecipes_ApplicationUserId",
                table: "ApplicationUserRecipes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRecipes_RecipeId",
                table: "ApplicationUserRecipes",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
