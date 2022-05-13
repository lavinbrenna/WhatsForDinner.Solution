namespace WhatsForDinner.Models
{
  public class ApplicationUserWeek
  {
    public int ApplicationUserWeekId{get;set;}
    public string ApplicationUserId{get;set;}
    public int RecipeWeekId{get;set;}
    public virtual ApplicationUser User {get;set;}
    public virtual RecipeWeek RecipeWeek {get;set;}
  }
}