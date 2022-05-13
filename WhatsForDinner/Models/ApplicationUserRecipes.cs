using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;

namespace WhatsForDinner.Models
{
  public class ApplicationUserRecipes
  {
    public int ApplicationUserRecipesId {get;set;}
    public string ApplicationUserId {get;set;}
    public string RecipeList{get;set;}
    public virtual Recipe Recipe {get;set;}
    public virtual ApplicationUser User {get;set;}
  }
}