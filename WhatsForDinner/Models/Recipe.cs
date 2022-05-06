using System.Collections.Generic;
using System;

namespace WhatsForDinner.Models
{
  public class Recipe
  {
    public Recipe()
    {
      this.JoinEntities = new HashSet<CategoryRecipe>();
    }
    public int RecipeId{get;set;}
    public string Title{get;set;}
    public string RecipeUrl{get;set;}
    public string Ingredients{get;set;}
    public int MinFrequency{get;set;}
    public int MaxFrequency{get;set;}
    public string PreferredDay{get;set;}
    public virtual ApplicationUser User {get;set;}
    public virtual ICollection <CategoryRecipe> JoinEntities {get;}
  }
}