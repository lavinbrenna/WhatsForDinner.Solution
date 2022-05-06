using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;

namespace WhatsForDinner.Models{
  public class ApplicationUser : IdentityUser
  {
    public ApplicationUser()
    {
      this.JoinEntities = new HashSet<ApplicationUserRecipe>();
    }
    public virtual ICollection<ApplicationUserRecipe> JoinEntities {get;set;}
  }
}