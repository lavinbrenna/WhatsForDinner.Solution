using System.Collections.Generic;
using System;

namespace WhatsForDinner.Models
{
  public class RecipeWeek
  {
    // public RecipeWeek(){
    //   this.JoinEntities = new HashSet<RecipeDay>();
    // }
    public int RecipeWeekId {get;set;}
    public string ApplicationUserId {get;set;}
    public DateTime WeekOf {get;set;}
    public bool BreakfastPlan{get;set;}
    public bool LunchPlan{get;set;}
    public bool DinnerPlan {get;set;}
    public bool EverythingPlan{get;set;}

    public virtual List<RecipeDay> Week {get;set;}
    // public virtual ICollection<RecipeDay> JoinEntities{get;set;}
    public virtual ApplicationUser User{get;set;}
  }
}