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
    private readonly Random _random = new Random();
    public static List<Recipe> GetBreakfastRecipes(List<Recipe> recipeList){
      List<Recipe> breakfastList = new List<Recipe>{};
      foreach(Recipe recipe in recipeList)
      {
      if(recipe.isBreakfast){
        breakfastList.Add(recipe);
        } 
      }
      return breakfastList;
    }
    public static List<Recipe> GetLunchRecipes(List<Recipe> recipeList){
      List<Recipe> lunchList = new List<Recipe>{};
      foreach(Recipe recipe in recipeList)
      {
        if(recipe.isLunch){
          lunchList.Add(recipe);
        }
      }
      return lunchList;
    }
    public static List<Recipe> GetDinnerRecipes(List<Recipe> recipeList){
      List<Recipe> dinnerList = new List<Recipe>{};
      foreach(Recipe recipe in recipeList)
      {
        if(recipe.isDinner){
          dinnerList.Add(recipe);
        }
      }
      return dinnerList;
    }
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
        if(recipeList[random].MinFrequency < 7 && recipeList[random].MinFrequency <= 4){
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