using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsForDinner.Migrations
{
    public partial class updated_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreakfastRecipes_Breakfasts_BreakfastId",
                table: "BreakfastRecipes");

            migrationBuilder.DropForeignKey(
                name: "FK_DinnerRecipes_Dinners_DinnerId",
                table: "DinnerRecipes");

            migrationBuilder.DropForeignKey(
                name: "FK_LunchRecipes_Lunches_LunchId",
                table: "LunchRecipes");

            migrationBuilder.DropTable(
                name: "Breakfasts");

            migrationBuilder.DropTable(
                name: "Dinners");

            migrationBuilder.DropTable(
                name: "Lunches");

            migrationBuilder.DropIndex(
                name: "IX_LunchRecipes_LunchId",
                table: "LunchRecipes");

            migrationBuilder.DropIndex(
                name: "IX_DinnerRecipes_DinnerId",
                table: "DinnerRecipes");

            migrationBuilder.DropIndex(
                name: "IX_BreakfastRecipes_BreakfastId",
                table: "BreakfastRecipes");

            migrationBuilder.DropColumn(
                name: "LunchId",
                table: "LunchRecipes");

            migrationBuilder.DropColumn(
                name: "DinnerId",
                table: "DinnerRecipes");

            migrationBuilder.DropColumn(
                name: "BreakfastId",
                table: "BreakfastRecipes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LunchId",
                table: "LunchRecipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DinnerId",
                table: "DinnerRecipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BreakfastId",
                table: "BreakfastRecipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Breakfasts",
                columns: table => new
                {
                    BreakfastId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breakfasts", x => x.BreakfastId);
                });

            migrationBuilder.CreateTable(
                name: "Dinners",
                columns: table => new
                {
                    DinnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dinners", x => x.DinnerId);
                });

            migrationBuilder.CreateTable(
                name: "Lunches",
                columns: table => new
                {
                    LunchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lunches", x => x.LunchId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LunchRecipes_LunchId",
                table: "LunchRecipes",
                column: "LunchId");

            migrationBuilder.CreateIndex(
                name: "IX_DinnerRecipes_DinnerId",
                table: "DinnerRecipes",
                column: "DinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_BreakfastRecipes_BreakfastId",
                table: "BreakfastRecipes",
                column: "BreakfastId");

            migrationBuilder.AddForeignKey(
                name: "FK_BreakfastRecipes_Breakfasts_BreakfastId",
                table: "BreakfastRecipes",
                column: "BreakfastId",
                principalTable: "Breakfasts",
                principalColumn: "BreakfastId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DinnerRecipes_Dinners_DinnerId",
                table: "DinnerRecipes",
                column: "DinnerId",
                principalTable: "Dinners",
                principalColumn: "DinnerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LunchRecipes_Lunches_LunchId",
                table: "LunchRecipes",
                column: "LunchId",
                principalTable: "Lunches",
                principalColumn: "LunchId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
