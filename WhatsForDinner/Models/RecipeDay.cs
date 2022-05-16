using System.Collections.Generic;
namespace WhatsForDinner.Models{
    public class RecipeDay{
    // public RecipeDay(){
    //   this.JoinEntities1 = new HashSet<BreakfastRecipe>();
    //   this.JoinEntities2 = new HashSet<LunchRecipe>();
    //   this.JoinEntities3 = new HashSet<DinnerRecipe>();
    // }
    public int RecipeDayId {get;set;}
    public virtual Recipe Breakfast {get;set;}
    public virtual Recipe Lunch {get;set;}
    public virtual Recipe Dinner {get;set;}
    // public virtual ICollection<BreakfastRecipe> JoinEntities1{get;set;}
    // public virtual ICollection<LunchRecipe> JoinEntities2{get;set;}
    // public virtual ICollection<DinnerRecipe> JoinEntities3{get;set;}
    public virtual ApplicationUser User {get;set;}
  }
}