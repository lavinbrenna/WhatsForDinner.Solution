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
    public virtual ApplicationUser User {get;set;}
    public virtual List<Recipe> WeeklyRecipes {get;set;}
    private readonly Random _random = new Random();

    public static List<Recipe> RandomBreakfasts(List<Recipe> recipeList)
    {
      Random rnd = new Random();
      List<Recipe> WeekBreakfast = new List<Recipe>{};
      while(WeekBreakfast.Count != 7){
      int random = rnd.Next(0, recipeList.Count);
      if(!WeekBreakfast.Contains(recipeList[random]))
      {
        WeekBreakfast.Add(recipeList[random]);
      }
      else if(WeekBreakfast.Contains(recipeList[random]))
      {
        if(recipeList[random].MinFrequency < 7 && recipeList[random].MinFrequency <= 3){
          WeekBreakfast.Add(recipeList[random]);
        }
      }
    }
    return WeekBreakfast;
    }

    public static List<Recipe> RandomLunches(List<Recipe> recipeList)
    {
      Random rnd = new Random();
      List<Recipe> WeekLunch = new List<Recipe>{};
      while(WeekLunch.Count != 7){
      int random = rnd.Next(0, recipeList.Count);
      if(!WeekLunch.Contains(recipeList[random]))
      {
        WeekLunch.Add(recipeList[random]);
      }
      else if(WeekLunch.Contains(recipeList[random]))
      {
        if(recipeList[random].MinFrequency < 7 && recipeList[random].MinFrequency <= 3){
          WeekLunch.Add(recipeList[random]);
        }
      }
    }
    return WeekLunch;
    }
    public static List<Recipe> RandomDinners(List<Recipe> recipeList)
    {
      Random rnd = new Random();
      List<Recipe> WeekDinner = new List<Recipe>{};
      while(WeekDinner.Count != 7){
      int random = rnd.Next(0, recipeList.Count);
      if(!WeekDinner.Contains(recipeList[random]))
      {
        WeekDinner.Add(recipeList[random]);
      }
      else if(WeekDinner.Contains(recipeList[random]))
      {
        if(recipeList[random].MinFrequency < 7 && recipeList[random].MinFrequency <= 3){
          WeekDinner.Add(recipeList[random]);
        }
      }
    }
    return WeekDinner;
    }

    public static List<Recipe> GetWeekPlan(List<Recipe> breakfastList, List<Recipe> lunchList, List<Recipe> dinnerList){
      List<Recipe> WeekRecipes = new List <Recipe>{};
      foreach(Recipe recipe in breakfastList)
      {
        WeekRecipes.Add(recipe);
      }
      foreach(Recipe recipe in lunchList)
      {
        WeekRecipes.Add(recipe);
      }
    foreach(Recipe recipe in dinnerList)
      {
        WeekRecipes.Add(recipe);
      }
      return WeekRecipes;
    }



  }
}


// extra features not implemented :

 // public static Recipe RandomBreakfast(List<Recipe> recipeList)
    // {
    //   Random rndB = new Random();
    //   int rndBreakfast = rndB.Next(0, recipeList.Count);
    //   Recipe breakfast = recipeList[rndBreakfast];
    //   return breakfast;
    // }

    // public static Recipe RandomLunch(List<Recipe> recipeList)
    // {
    //   Random rndL = new Random();
    //   int rndLunch = rndL.Next(0, recipeList.Count);
    //   Recipe lunch = recipeList[rndLunch];
    //   return lunch;
    // }  

  // public static Recipe RandomDinner(List<Recipe> recipeList)
  //   {
  //     Random rndD = new Random();
  //     int rndDinner = rndD.Next(0, recipeList.Count);
  //     Recipe dinner = recipeList[rndDinner];
  //     return dinner;
  //   }

        // public static List<Recipe> ReRollDay(List<Recipe> breakfastList, List<Recipe> lunchList, List<Recipe> dinnerList)
    // {
    //   List<Recipe> DayRecipes = new List<Recipe>{};
    //   Recipe breakfast = Recipe.RandomBreakfast(breakfastList);
    //   Recipe lunch = Recipe.RandomLunch(lunchList);
    //   Recipe dinner = Recipe.RandomDinner(dinnerList);
    //   DayRecipes.Add(breakfast);
    //   DayRecipes.Add(lunch);
    //   DayRecipes.Add(dinner);
    //   return DayRecipes;
    // }