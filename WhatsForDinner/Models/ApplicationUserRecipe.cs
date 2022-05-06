using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;

namespace WhatsForDinner.Models
{
  public class ApplicationUserRecipe
  {
    public int ApplicationUserRecipeId {get;set;}
    public string ApplicationUserId {get;set;}
    public int RecipeId {get;set;}
    public virtual Recipe Recipe {get;set;}
    public virtual ApplicationUser ApplicationUser {get;set;}
  }
}