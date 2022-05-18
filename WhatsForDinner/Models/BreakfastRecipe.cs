namespace WhatsForDinner.Models
{
  public class BreakfastRecipe{
    public int BreakfastRecipeId{ get; set;}
    public int RecipeId {get;set;}
    public virtual Recipe Recipe{get;set;}
  }
}