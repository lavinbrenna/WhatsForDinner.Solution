using System.Collections.Generic;
using System;

namespace WhatsForDinner.Models
{
  public class Recipe
  {
    public Recipe()
    {
      this.JoinEntities = new HashSet<UserCalendar>();
    }
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
    public virtual ICollection<UserCalendar> JoinEntities {get;set;}

    private readonly Random _random = new Random();

    public static List<Recipe> CreateRandomList(List<Recipe> Recipes){
      List<Recipe> randomRecipe = new List<Recipe>{};
      while(randomRecipe.Count != 7){
        Random rnd = new Random();
        int recipeToAdd = rnd.Next(0, Recipes.Count);
        if(!randomRecipe.Contains(Recipes[recipeToAdd])){
          randomRecipe.Add(Recipes[recipeToAdd]);
        }
      }
      return randomRecipe;
    }

    // public static List<Recipe> CreateCalendar()
    // {
    //   List<Recipe> RecipeCalendar = new List<Recipe>{};
    // }
    // public static List<Recipe> UpcomingRecipes(List recipeList)
    // {
    // }
  }
}