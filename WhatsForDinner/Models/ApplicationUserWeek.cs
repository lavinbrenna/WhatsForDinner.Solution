namespace WhatsForDinner.Models
{
  public class ApplicationUserWeek
  {
    public int ApplicationUserWeekId{get;set;}
    public string ApplicationUserId{get;set;}
    public int RecipeWeekId{get;set;}
    public bool BreakfastPlan{get;set;}
    public bool LunchPlan{get;set;}
    public bool DinnerPlan{get;set;}
    public bool EverythingPlan{get;set;}

    public virtual ApplicationUser User {get;set;}
    public virtual RecipeWeek RecipeWeek {get;set;}
  }
}