using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsForDinner.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Name = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Name = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Value = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    RecipeUrl = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Ingredients = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    MinFrequency = table.Column<int>(type: "int", nullable: false),
                    MaxFrequency = table.Column<int>(type: "int", nullable: false),
                    isBreakfast = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    isLunch = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    isDinner = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    RecipeId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeId);
                    table.ForeignKey(
                        name: "FK_Recipes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recipes_Recipes_RecipeId1",
                        column: x => x.RecipeId1,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeWeeks",
                columns: table => new
                {
                    RecipeWeekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    WeekOf = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeWeeks", x => x.RecipeWeekId);
                    table.ForeignKey(
                        name: "FK_RecipeWeeks_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BreakfastRecipes",
                columns: table => new
                {
                    BreakfastRecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    BreakfastId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    BreakfastRecipeId1 = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_BreakfastRecipes_BreakfastRecipes_BreakfastRecipeId1",
                        column: x => x.BreakfastRecipeId1,
                        principalTable: "BreakfastRecipes",
                        principalColumn: "BreakfastRecipeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BreakfastRecipes_Breakfasts_BreakfastId",
                        column: x => x.BreakfastId,
                        principalTable: "Breakfasts",
                        principalColumn: "BreakfastId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreakfastRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DinnerRecipes",
                columns: table => new
                {
                    DinnerRecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    DinnerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    DinnerRecipeId1 = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_DinnerRecipes_DinnerRecipes_DinnerRecipeId1",
                        column: x => x.DinnerRecipeId1,
                        principalTable: "DinnerRecipes",
                        principalColumn: "DinnerRecipeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DinnerRecipes_Dinners_DinnerId",
                        column: x => x.DinnerId,
                        principalTable: "Dinners",
                        principalColumn: "DinnerId",
                        onDelete: ReferentialAction.Cascade);
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
                    LunchId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    LunchRecipeId1 = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_LunchRecipes_Lunches_LunchId",
                        column: x => x.LunchId,
                        principalTable: "Lunches",
                        principalColumn: "LunchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LunchRecipes_LunchRecipes_LunchRecipeId1",
                        column: x => x.LunchRecipeId1,
                        principalTable: "LunchRecipes",
                        principalColumn: "LunchRecipeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LunchRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserWeeks",
                columns: table => new
                {
                    ApplicationUserWeekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    RecipeWeekId = table.Column<int>(type: "int", nullable: false),
                    BreakfastPlan = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LunchPlan = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DinnerPlan = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EverythingPlan = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserWeeks", x => x.ApplicationUserWeekId);
                    table.ForeignKey(
                        name: "FK_ApplicationUserWeeks_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationUserWeeks_RecipeWeeks_RecipeWeekId",
                        column: x => x.RecipeWeekId,
                        principalTable: "RecipeWeeks",
                        principalColumn: "RecipeWeekId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    DayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    BreakfastRecipeId = table.Column<int>(type: "int", nullable: false),
                    LunchRecipeId = table.Column<int>(type: "int", nullable: false),
                    DinnerRecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.DayId);
                    table.ForeignKey(
                        name: "FK_Days_BreakfastRecipes_BreakfastRecipeId",
                        column: x => x.BreakfastRecipeId,
                        principalTable: "BreakfastRecipes",
                        principalColumn: "BreakfastRecipeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Days_DinnerRecipes_DinnerRecipeId",
                        column: x => x.DinnerRecipeId,
                        principalTable: "DinnerRecipes",
                        principalColumn: "DinnerRecipeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Days_LunchRecipes_LunchRecipeId",
                        column: x => x.LunchRecipeId,
                        principalTable: "LunchRecipes",
                        principalColumn: "LunchRecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeDays",
                columns: table => new
                {
                    RecipeDayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DayId = table.Column<int>(type: "int", nullable: false),
                    RecipeWeekId = table.Column<int>(type: "int", nullable: true),
                    RecipeWeekId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDays", x => x.RecipeDayId);
                    table.ForeignKey(
                        name: "FK_RecipeDays_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "DayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeDays_RecipeWeeks_RecipeWeekId",
                        column: x => x.RecipeWeekId,
                        principalTable: "RecipeWeeks",
                        principalColumn: "RecipeWeekId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeDays_RecipeWeeks_RecipeWeekId1",
                        column: x => x.RecipeWeekId1,
                        principalTable: "RecipeWeeks",
                        principalColumn: "RecipeWeekId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserWeeks_ApplicationUserId",
                table: "ApplicationUserWeeks",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserWeeks_RecipeWeekId",
                table: "ApplicationUserWeeks",
                column: "RecipeWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BreakfastRecipes_BreakfastId",
                table: "BreakfastRecipes",
                column: "BreakfastId");

            migrationBuilder.CreateIndex(
                name: "IX_BreakfastRecipes_BreakfastRecipeId1",
                table: "BreakfastRecipes",
                column: "BreakfastRecipeId1");

            migrationBuilder.CreateIndex(
                name: "IX_BreakfastRecipes_RecipeId",
                table: "BreakfastRecipes",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_BreakfastRecipes_UserId",
                table: "BreakfastRecipes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_BreakfastRecipeId",
                table: "Days",
                column: "BreakfastRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_DinnerRecipeId",
                table: "Days",
                column: "DinnerRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_LunchRecipeId",
                table: "Days",
                column: "LunchRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_DinnerRecipes_DinnerId",
                table: "DinnerRecipes",
                column: "DinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_DinnerRecipes_DinnerRecipeId1",
                table: "DinnerRecipes",
                column: "DinnerRecipeId1");

            migrationBuilder.CreateIndex(
                name: "IX_DinnerRecipes_RecipeId",
                table: "DinnerRecipes",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_DinnerRecipes_UserId",
                table: "DinnerRecipes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LunchRecipes_LunchId",
                table: "LunchRecipes",
                column: "LunchId");

            migrationBuilder.CreateIndex(
                name: "IX_LunchRecipes_LunchRecipeId1",
                table: "LunchRecipes",
                column: "LunchRecipeId1");

            migrationBuilder.CreateIndex(
                name: "IX_LunchRecipes_RecipeId",
                table: "LunchRecipes",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_LunchRecipes_UserId",
                table: "LunchRecipes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDays_DayId",
                table: "RecipeDays",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDays_RecipeWeekId",
                table: "RecipeDays",
                column: "RecipeWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDays_RecipeWeekId1",
                table: "RecipeDays",
                column: "RecipeWeekId1");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeId1",
                table: "Recipes",
                column: "RecipeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserId",
                table: "Recipes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeWeeks_ApplicationUserId",
                table: "RecipeWeeks",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserWeeks");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "RecipeDays");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "RecipeWeeks");

            migrationBuilder.DropTable(
                name: "BreakfastRecipes");

            migrationBuilder.DropTable(
                name: "DinnerRecipes");

            migrationBuilder.DropTable(
                name: "LunchRecipes");

            migrationBuilder.DropTable(
                name: "Breakfasts");

            migrationBuilder.DropTable(
                name: "Dinners");

            migrationBuilder.DropTable(
                name: "Lunches");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
