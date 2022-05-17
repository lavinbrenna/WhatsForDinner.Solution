using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace WhatsForDinner.Models

{
  public class ImportedRecipe
  {
    public int ImportedRecipeId{get;set;}
    public string title {get;set;}
    public string image {get;set;}
    public string sourceUrl{get;set;}
    public bool Breakfast{get;set;}
    public bool Lunch{get;set;}
    public bool Dinner{get;set;}
    public virtual ApplicationUser User {get;set;}
    public static ImportedRecipe GetRecipe(string apiKey, string recipeUrl)
    {
      var apiCallTask = ApiHelper.ApiCall(apiKey, recipeUrl);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      ImportedRecipe importedRecipe = JsonConvert.DeserializeObject<ImportedRecipe>(jsonResponse.ToString());
      return importedRecipe;
    }
    public static Recipe ConvertToRecipe(ImportedRecipe importedRecipe)
    {
      Recipe newRecipe = new Recipe(){Title = importedRecipe.title, RecipeUrl = importedRecipe.sourceUrl, isBreakfast = importedRecipe.Breakfast, isLunch = importedRecipe.Lunch, isDinner = importedRecipe.Dinner, User = importedRecipe.User};
      return newRecipe;
    }
  }
}