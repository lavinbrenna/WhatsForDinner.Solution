using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;

namespace WhatsForDinner.Models{
  public class ApplicationUser : IdentityUser
  {
    public virtual List<Recipe> WeeklyRecipes{get;set;}
  }
}