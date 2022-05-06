using System.Collections.Generic;
using System;

namespace WhatsForDinner.Models
{
  public class Recipe
  {
    public Recipe()
    {
      this.JoinEntities = new HashSet<ApplicationUserRecipe>();
    }
  public int RecipeId{get;set;}
  public string Title{get;set;}
  public string RecipeUrl{get;set;}
  public string Ingredients{get;set;}
  public string Category{get;set;}
  public int MinFrequency{get;set;}
  public int MaxFrequency{get;set;}
  public string Breakfast{get;set;}
  public string Lunch {get;set;}
  public string Dinner {get;set;}
  public string PreferredDay{get;set;}

  public virtual ICollection<ApplicationUserRecipe> JoinEntities {get;}
  
  }
}