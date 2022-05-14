using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsForDinner.Migrations
{
    public partial class big_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "RecipeWeeks",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeWeeks_ApplicationUserId",
                table: "RecipeWeeks",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeWeeks_AspNetUsers_ApplicationUserId",
                table: "RecipeWeeks",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeWeeks_AspNetUsers_ApplicationUserId",
                table: "RecipeWeeks");

            migrationBuilder.DropIndex(
                name: "IX_RecipeWeeks_ApplicationUserId",
                table: "RecipeWeeks");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "RecipeWeeks");
        }
    }
}
