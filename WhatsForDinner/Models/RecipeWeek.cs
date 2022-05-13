using System.Collections.Generic;
using System;

namespace WhatsForDinner.Models
{
  public class RecipeWeek
  {
    public RecipeWeek(){
      this.JoinEntities = new HashSet<ApplicationUserWeek>();
    }
    public int RecipeWeekId {get;set;}
    public DateTime WeekOf {get;set;}
    public virtual List<RecipeDay> Week {get;set;}
    public virtual ICollection<ApplicationUserWeek> JoinEntities{get;}
  }
}