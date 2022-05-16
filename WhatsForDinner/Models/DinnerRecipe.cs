namespace WhatsForDinner.Models
{
  public class DinnerRecipe
  {
    public int DinnerRecipeId{get;set;}
    public int RecipeId {get;set;}
    public virtual Recipe Recipe{get;set;}
  }
}