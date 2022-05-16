namespace WhatsForDinner.Models
{
  public class LunchRecipe
  {
    public int LunchRecipeId{get;set;}
    public int RecipeId{get;set;}
    public virtual Recipe Recipe{get;set;}
  }
}