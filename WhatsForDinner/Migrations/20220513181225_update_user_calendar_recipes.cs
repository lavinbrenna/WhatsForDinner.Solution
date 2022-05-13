using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsForDinner.Migrations
{
    public partial class update_user_calendar_recipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_UserCalendars_UserCalendarId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_UserCalendarId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "UserCalendarId",
                table: "Recipes");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "UserCalendars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RecipeUserCalendar",
                columns: table => new
                {
                    JoinEntitiesUserCalendarId = table.Column<int>(type: "int", nullable: false),
                    RecipesRecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeUserCalendar", x => new { x.JoinEntitiesUserCalendarId, x.RecipesRecipeId });
                    table.ForeignKey(
                        name: "FK_RecipeUserCalendar_Recipes_RecipesRecipeId",
                        column: x => x.RecipesRecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeUserCalendar_UserCalendars_JoinEntitiesUserCalendarId",
                        column: x => x.JoinEntitiesUserCalendarId,
                        principalTable: "UserCalendars",
                        principalColumn: "UserCalendarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeUserCalendar_RecipesRecipeId",
                table: "RecipeUserCalendar",
                column: "RecipesRecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeUserCalendar");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "UserCalendars");

            migrationBuilder.AddColumn<int>(
                name: "UserCalendarId",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserCalendarId",
                table: "Recipes",
                column: "UserCalendarId");

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
