using System.Collections.Generic;

namespace WhatsForDinner.Models
{
  public class Category
  {
    public Category()
    {
      this.JoinEntities = new HashSet<CategoryRecipe>();
    }

    public int CategoryId {get;set;}
    public string MealType {get;set;}
    public virtual ICollection<CategoryRecipe> JoinEntities {get;set;}
  }
}