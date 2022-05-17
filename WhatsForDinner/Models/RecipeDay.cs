using System.Collections.Generic;
namespace WhatsForDinner.Models{
    public class RecipeDay{
    public int RecipeDayId {get;set;}
    public int BreakfastRecipeId{get;set;}
    public int LunchRecipeId {get;set;}
    public int DinnerRecipeId{get;set;}
    // public int RecipeWeekId {get;set;}
    // public virtual RecipeWeek RecipeWeek {get;set;}
    public virtual Recipe Breakfast {get;set;}
    public virtual Recipe Lunch {get;set;}
    public virtual Recipe Dinner {get;set;}
    public virtual ApplicationUser User {get;set;}
  }
}