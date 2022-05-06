using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WhatsForDinner.Models
{
  public class WhatsForDinnerContext: IdentityDbContext<ApplicationUser>
  {
    public DbSet<Recipe> Recipes {get;set;}
    public DbSet<Category> Categories {get;set;}
    public DbSet<CategoryRecipe> CategoryRecipe {get;set;}
    public WhatsForDinnerContext(DbContextOptions options) : base(options){}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}

