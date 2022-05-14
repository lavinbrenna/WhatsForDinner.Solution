using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsForDinner.Migrations
{
    public partial class new_data_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserWeek_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserWeek");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserWeek_RecipeWeek_RecipeWeekId",
                table: "ApplicationUserWeek");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeDays_RecipeWeek_RecipeWeekId",
                table: "RecipeDays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeWeek",
                table: "RecipeWeek");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserWeek",
                table: "ApplicationUserWeek");

            migrationBuilder.RenameTable(
                name: "RecipeWeek",
                newName: "RecipeWeeks");

            migrationBuilder.RenameTable(
                name: "ApplicationUserWeek",
                newName: "ApplicationUserWeeks");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserWeek_RecipeWeekId",
                table: "ApplicationUserWeeks",
                newName: "IX_ApplicationUserWeeks_RecipeWeekId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserWeek_ApplicationUserId",
                table: "ApplicationUserWeeks",
                newName: "IX_ApplicationUserWeeks_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeWeeks",
                table: "RecipeWeeks",
                column: "RecipeWeekId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserWeeks",
                table: "ApplicationUserWeeks",
                column: "ApplicationUserWeekId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserWeeks_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserWeeks",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserWeeks_RecipeWeeks_RecipeWeekId",
                table: "ApplicationUserWeeks",
                column: "RecipeWeekId",
                principalTable: "RecipeWeeks",
                principalColumn: "RecipeWeekId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeDays_RecipeWeeks_RecipeWeekId",
                table: "RecipeDays",
                column: "RecipeWeekId",
                principalTable: "RecipeWeeks",
                principalColumn: "RecipeWeekId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserWeeks_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserWeeks");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserWeeks_RecipeWeeks_RecipeWeekId",
                table: "ApplicationUserWeeks");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeDays_RecipeWeeks_RecipeWeekId",
                table: "RecipeDays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeWeeks",
                table: "RecipeWeeks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserWeeks",
                table: "ApplicationUserWeeks");

            migrationBuilder.RenameTable(
                name: "RecipeWeeks",
                newName: "RecipeWeek");

            migrationBuilder.RenameTable(
                name: "ApplicationUserWeeks",
                newName: "ApplicationUserWeek");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserWeeks_RecipeWeekId",
                table: "ApplicationUserWeek",
                newName: "IX_ApplicationUserWeek_RecipeWeekId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserWeeks_ApplicationUserId",
                table: "ApplicationUserWeek",
                newName: "IX_ApplicationUserWeek_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeWeek",
                table: "RecipeWeek",
                column: "RecipeWeekId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserWeek",
                table: "ApplicationUserWeek",
                column: "ApplicationUserWeekId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserWeek_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserWeek",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserWeek_RecipeWeek_RecipeWeekId",
                table: "ApplicationUserWeek",
                column: "RecipeWeekId",
                principalTable: "RecipeWeek",
                principalColumn: "RecipeWeekId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeDays_RecipeWeek_RecipeWeekId",
                table: "RecipeDays",
                column: "RecipeWeekId",
                principalTable: "RecipeWeek",
                principalColumn: "RecipeWeekId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
