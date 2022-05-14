
using System;

namespace WhatsForDinner.Models{
    public class RecipeDay{
    public int RecipeDayId {get;set;}
    public string DayName {get;set;}
    public virtual Recipe Breakfast{get;set;}
    public virtual Recipe Lunch {get;set;}
    public virtual Recipe Dinner {get;set;}
  }
}