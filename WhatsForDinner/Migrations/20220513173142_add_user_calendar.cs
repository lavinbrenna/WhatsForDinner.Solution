using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsForDinner.Migrations
{
    public partial class add_user_calendar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
