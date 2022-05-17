using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WhatsForDinner.Models
{
  public class WhatsForDinnerContext: IdentityDbContext<ApplicationUser>
  {
    public DbSet<Recipe> Recipes {get;set;}
    public DbSet<RecipeDay> RecipeDays{get;set;}
    public DbSet<RecipeWeek> RecipeWeeks{get;set;}
    public DbSet<BreakfastRecipe> BreakfastRecipes{get;set;}
    public DbSet<LunchRecipe> LunchRecipes{get;set;}
    public DbSet<DinnerRecipe> DinnerRecipes {get;set;}
    public DbSet<ImportedRecipe> ImportedRecipes{get;set;}
    public WhatsForDinnerContext(DbContextOptions options) : base(options){}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}

