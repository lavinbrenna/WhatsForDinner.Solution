using System.Collections.Generic;
using System;

namespace WhatsForDinner.Models
{
  public class Recipe
  {
    public int RecipeId{get;set;}
    public string Title{get;set;}
    public string RecipeUrl{get;set;}
    public string Ingredients{get;set;}
    public int MinFrequency{get;set;}
    public int MaxFrequency{get;set;}
    public bool isBreakfast {get;set;}
    public bool isLunch {get;set;}
    public bool isDinner {get;set;}
    public string PreferredDay{get;set;}
    public virtual ApplicationUser User {get;set;}

    // public static List<Recipe> CreateCalendar()
    // {
        
    // }
    // public static List<Recipe> UpcomingRecipes(List recipeList)
    // {
    // }
  }

  
}