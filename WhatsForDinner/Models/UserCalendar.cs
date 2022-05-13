using System.Collections.Generic;

namespace WhatsForDinner.Models
{
  public class UserCalendar
  {
    public int UserCalendarId {get;set;}
    public int RecipeId {get;set;}
    public virtual Recipe Recipe {get;set;}
    public virtual ApplicationUser User {get;set;}
  }
}