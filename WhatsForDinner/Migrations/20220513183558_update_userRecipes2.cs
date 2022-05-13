using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsForDinner.Migrations
{
    public partial class update_userRecipes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCalendars_Recipes_RecipeId",
                table: "UserCalendars");

            migrationBuilder.DropIndex(
                name: "IX_UserCalendars_RecipeId",
                table: "UserCalendars");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "UserCalendars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "UserCalendars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserCalendars_RecipeId",
                table: "UserCalendars",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCalendars_Recipes_RecipeId",
                table: "UserCalendars",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
