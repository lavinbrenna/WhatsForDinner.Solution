using System.Collections.Generic;
using System;

namespace WhatsForDinner.Models
{
  public class RecipeWeek
  {
    public RecipeWeek(){
      this.JoinEntities = new HashSet<ApplicationUserWeek>();
      this.JoinEntities1 = new HashSet<RecipeDay>();
    }
    public int RecipeWeekId {get;set;}
    public string ApplicationUserId {get;set;}
    public DateTime WeekOf {get;set;}
    public virtual List<RecipeDay> Week {get;set;}
    public virtual ApplicationUser User{get;set;}
    public virtual ICollection<ApplicationUserWeek> JoinEntities{get;}
    public virtual ICollection<RecipeDay> JoinEntities1{get;}
  }
}