using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WhatsForDinner.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using System;
using System.Data;
namespace WhatsForDinner.Controllers
{
  [Authorize]

  public class CalendarsController : Controller
  {
    private readonly WhatsForDinnerContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public CalendarsController(UserManager<ApplicationUser> userManager, WhatsForDinnerContext db)
    {
      _userManager = userManager;
      _db = db;
    }

      public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userCalendars = _db.RecipeWeeks.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(userCalendars);
    }

    public ActionResult Create(){
      return View();
    }
    public async Task<ActionResult> CreateAll()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userRecipes = _db.Recipes.Where(entry=> entry.User.Id==currentUser.Id).ToList();
      List<Recipe> UserBreakfast = new List<Recipe>{};
      List<Recipe> UserLunch = new List<Recipe>{};
      List<Recipe> UserDinner = new List<Recipe>{};
      foreach(Recipe recipe in userRecipes){
        if(recipe.isBreakfast){
          UserBreakfast.Add(recipe);
        }
        else if(recipe.isLunch){
          UserLunch.Add(recipe);
        }
        else{
          UserDinner.Add(recipe);
        }
      }
      if(userRecipes.Count == 0){
        return View(userRecipes);
      }
      else if(userRecipes.Count <= 7 && UserBreakfast.Count >= 1 && UserLunch.Count >=1 && UserDinner.Count >=1 )
      {
        List<Recipe> WeekBreakfast = Recipe.RandomBreakfasts(UserBreakfast);
        List<Recipe> WeekLunch = Recipe.RandomLunches(UserLunch);
        List<Recipe> WeekDinner = Recipe.RandomDinners(UserBreakfast);
        List<Recipe> WeekRecipes = Recipe.GetWeekPlan(WeekBreakfast, WeekLunch, WeekDinner);
        return View(WeekRecipes);
      }
      else
      {
        List<Recipe> WeekBreakfast = Recipe.RandomBreakfasts(UserBreakfast);
        List<Recipe> WeekLunch = Recipe.RandomLunches(UserLunch);
        List<Recipe> WeekDinner = Recipe.RandomDinners(UserDinner);
        List<Recipe> WeekRecipes = Recipe.GetWeekPlan(WeekBreakfast, WeekLunch, WeekDinner);
      return View(WeekRecipes);
      }
    }

    [HttpPost]
    public async Task<ActionResult> CreateAll(List<Recipe> WeekRecipes)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      RecipeDay RecipeMonday = new RecipeDay(){BreakfastRecipeId = WeekRecipes[0].RecipeId, LunchRecipeId = WeekRecipes[7].RecipeId, DinnerRecipeId = WeekRecipes[14].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeMonday);
      RecipeDay RecipeTuesday = new RecipeDay(){BreakfastRecipeId = WeekRecipes[1].RecipeId, LunchRecipeId = WeekRecipes[8].RecipeId, DinnerRecipeId = WeekRecipes[15].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeTuesday);
      RecipeDay RecipeWednesday = new RecipeDay(){BreakfastRecipeId = WeekRecipes[2].RecipeId, LunchRecipeId = WeekRecipes[9].RecipeId, DinnerRecipeId = WeekRecipes[16].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeWednesday);
      RecipeDay RecipeThursday = new RecipeDay(){BreakfastRecipeId = WeekRecipes[3].RecipeId, LunchRecipeId = WeekRecipes[10].RecipeId, DinnerRecipeId = WeekRecipes[17].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeThursday);
      RecipeDay RecipeFriday = new RecipeDay(){BreakfastRecipeId = WeekRecipes[4].RecipeId, LunchRecipeId = WeekRecipes[11].RecipeId, DinnerRecipeId = WeekRecipes[18].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeFriday);
      RecipeDay RecipeSaturday = new RecipeDay(){BreakfastRecipeId = WeekRecipes[5].RecipeId, LunchRecipeId = WeekRecipes[12].RecipeId, DinnerRecipeId = WeekRecipes[19].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeSaturday);
      RecipeDay RecipeSunday = new RecipeDay(){BreakfastRecipeId = WeekRecipes[6].RecipeId, LunchRecipeId = WeekRecipes[13].RecipeId, DinnerRecipeId = WeekRecipes[20].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeSunday);
      DateTime weekDate = DateTime.Now;
      RecipeWeek thisWeek = new RecipeWeek() { Week = new List<RecipeDay> { RecipeMonday, RecipeTuesday, RecipeWednesday, RecipeThursday, RecipeFriday, RecipeSaturday, RecipeSunday }, ApplicationUserId = currentUser.Id, EverythingPlan = true};
      if(weekDate.DayOfWeek == DayOfWeek.Monday){
        thisWeek.WeekOf = weekDate;
      }
      else if(weekDate.DayOfWeek != DayOfWeek.Monday){
        if(weekDate.DayOfWeek == DayOfWeek.Tuesday)
        {thisWeek.WeekOf = weekDate.AddDays(6);}
        else if(weekDate.DayOfWeek == DayOfWeek.Wednesday)
        {thisWeek.WeekOf = weekDate.AddDays(5);}
        else if(weekDate.DayOfWeek == DayOfWeek.Thursday)
        {thisWeek.WeekOf = weekDate.AddDays(4);}
        else if(weekDate.DayOfWeek == DayOfWeek.Friday)
        {thisWeek.WeekOf = weekDate.AddDays(3);}
        else if(weekDate.DayOfWeek == DayOfWeek.Saturday)
        {thisWeek.WeekOf = weekDate.AddDays(2);}
        else
        {thisWeek.WeekOf = weekDate.AddDays(1);}
      }
      _db.RecipeWeeks.Add(thisWeek);
      _db.SaveChanges();
      Console.WriteLine(thisWeek.Week[0].BreakfastRecipeId);
      return RedirectToAction("Index");
    }

  //   public async Task<ActionResult> CreateBreakfast()
  //   {
  //     var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
  //     var currentUser = await _userManager.FindByIdAsync(userId);
  //     var userRecipes = _db.Recipes.Where(entry=> entry.User.Id==currentUser.Id).ToList();
  //     List<Recipe> UserBreakfast = new List<Recipe>{};

  //     foreach(Recipe recipe in userRecipes){
  //       if(recipe.isBreakfast){
  //         UserBreakfast.Add(recipe);
  //       }
  //     }
  //     if(userRecipes.Count == 0){
  //       return View(userRecipes);
  //     }
  //     else
  //     {
  //       List<Recipe> WeekBreakfast = Recipe.RandomBreakfasts(UserBreakfast);
  //     return View(WeekBreakfast);
  //     }
  //   }

  // [HttpPost]
  //   public async Task<ActionResult> CreateBreakfast(List<Recipe> WeekBreakfast)
  //   {
  //     var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
  //     var currentUser = await _userManager.FindByIdAsync(userId);
  //     RecipeDay RecipeMonday = new RecipeDay(){BreakfastRecipeId = WeekBreakfast[0].RecipeId,User = currentUser};
  //     _db.RecipeDays.Add(RecipeMonday);
  //     RecipeDay RecipeTuesday = new RecipeDay(){BreakfastRecipeId = WeekBreakfast[1].RecipeId,LunchRecipeId = WeekBreakfast[1].RecipeId, DinnerRecipeId = WeekBreakfast[1].RecipeId, User = currentUser};
  //     _db.RecipeDays.Add(RecipeTuesday);
  //     RecipeDay RecipeWednesday = new RecipeDay(){BreakfastRecipeId = WeekBreakfast[2].RecipeId, LunchRecipeId = WeekBreakfast[2].RecipeId, DinnerRecipeId = WeekBreakfast[2].RecipeId,User = currentUser};
  //     _db.RecipeDays.Add(RecipeWednesday);
  //     RecipeDay RecipeThursday = new RecipeDay(){BreakfastRecipeId = WeekBreakfast[3].RecipeId, LunchRecipeId = WeekBreakfast[3].RecipeId, DinnerRecipeId = WeekBreakfast[3].RecipeId,User = currentUser};
  //     _db.RecipeDays.Add(RecipeThursday);
  //     RecipeDay RecipeFriday = new RecipeDay(){BreakfastRecipeId = WeekBreakfast[4].RecipeId,LunchRecipeId = WeekBreakfast[4].RecipeId, DinnerRecipeId = WeekBreakfast[4].RecipeId, User = currentUser};
  //     _db.RecipeDays.Add(RecipeFriday);
  //     RecipeDay RecipeSaturday = new RecipeDay(){BreakfastRecipeId = WeekBreakfast[5].RecipeId,LunchRecipeId = WeekBreakfast[5].RecipeId, DinnerRecipeId = WeekBreakfast[5].RecipeId,User = currentUser};
  //     _db.RecipeDays.Add(RecipeSaturday);
  //     RecipeDay RecipeSunday = new RecipeDay(){BreakfastRecipeId = WeekBreakfast[6].RecipeId,LunchRecipeId = WeekBreakfast[6].RecipeId, DinnerRecipeId = WeekBreakfast[6].RecipeId, User = currentUser};
  //     _db.RecipeDays.Add(RecipeSunday);
  //     DateTime weekDate = DateTime.Now;
  //     RecipeWeek thisWeek = new RecipeWeek() { Week = new List<RecipeDay> { RecipeMonday, RecipeTuesday, RecipeWednesday, RecipeThursday, RecipeFriday, RecipeSaturday, RecipeSunday }, ApplicationUserId = currentUser.Id, BreakfastPlan = true};
  //     if(weekDate.DayOfWeek == DayOfWeek.Monday){
  //       thisWeek.WeekOf = weekDate;
  //     }
  //     else if(weekDate.DayOfWeek != DayOfWeek.Monday){
  //       if(weekDate.DayOfWeek == DayOfWeek.Tuesday)
  //       {thisWeek.WeekOf = weekDate.AddDays(6);}
  //       else if(weekDate.DayOfWeek == DayOfWeek.Wednesday)
  //       {thisWeek.WeekOf = weekDate.AddDays(5);}
  //       else if(weekDate.DayOfWeek == DayOfWeek.Thursday)
  //       {thisWeek.WeekOf = weekDate.AddDays(4);}
  //       else if(weekDate.DayOfWeek == DayOfWeek.Friday)
  //       {thisWeek.WeekOf = weekDate.AddDays(3);}
  //       else if(weekDate.DayOfWeek == DayOfWeek.Saturday)
  //       {thisWeek.WeekOf = weekDate.AddDays(2);}
  //       else
  //       {thisWeek.WeekOf = weekDate.AddDays(1);}
  //     }
  //     _db.RecipeWeeks.Add(thisWeek);
  //     _db.SaveChanges();
  //     Console.WriteLine(thisWeek.Week[0].Breakfast.Title);
  //     return RedirectToAction("Index");
  //   }

  //   public async Task<ActionResult> CreateLunch()
  //   {
  //     var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
  //     var currentUser = await _userManager.FindByIdAsync(userId);
  //     var userRecipes = _db.Recipes.Where(entry=> entry.User.Id==currentUser.Id).ToList();
  //     List<Recipe> UserLunch = new List<Recipe>{};

  //     foreach(Recipe recipe in userRecipes){
  //       if(recipe.isLunch){
  //         UserLunch.Add(recipe);
  //       }
  //     }
  //     if(userRecipes.Count == 0){
  //       return View(userRecipes);
  //     }
  //     else
  //     {
  //       List<Recipe> WeekLunch = Recipe.RandomLunches(UserLunch);
  //     return View(WeekLunch);
  //     }
  //   }

  // [HttpPost]
  //   public async Task<ActionResult> CreateLunch(List<Recipe> WeekLunch)
  //   {
  //     var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
  //     var currentUser = await _userManager.FindByIdAsync(userId);
  //     RecipeDay RecipeMonday = new RecipeDay(){LunchRecipeId = WeekLunch[0].RecipeId,User = currentUser};
  //     _db.RecipeDays.Add(RecipeMonday);
  //     RecipeDay RecipeTuesday = new RecipeDay(){LunchRecipeId = WeekLunch[1].RecipeId, User = currentUser};
  //     _db.RecipeDays.Add(RecipeTuesday);
  //     RecipeDay RecipeWednesday = new RecipeDay(){LunchRecipeId = WeekLunch[2].RecipeId, User = currentUser};
  //     _db.RecipeDays.Add(RecipeWednesday);
  //     RecipeDay RecipeThursday = new RecipeDay(){LunchRecipeId = WeekLunch[3].RecipeId, User = currentUser};
  //     _db.RecipeDays.Add(RecipeThursday);
  //     RecipeDay RecipeFriday = new RecipeDay(){LunchRecipeId = WeekLunch[4].RecipeId, User = currentUser};
  //     _db.RecipeDays.Add(RecipeFriday);
  //     RecipeDay RecipeSaturday = new RecipeDay(){LunchRecipeId = WeekLunch[5].RecipeId,User = currentUser};
  //     _db.RecipeDays.Add(RecipeSaturday);
  //     RecipeDay RecipeSunday = new RecipeDay(){LunchRecipeId = WeekLunch[6].RecipeId, User = currentUser};
  //     _db.RecipeDays.Add(RecipeSunday);
  //     DateTime weekDate = DateTime.Now;
  //     RecipeWeek thisWeek = new RecipeWeek() { Week = new List<RecipeDay> { RecipeMonday, RecipeTuesday, RecipeWednesday, RecipeThursday, RecipeFriday, RecipeSaturday, RecipeSunday }, ApplicationUserId = currentUser.Id, LunchPlan = true};
  //     if(weekDate.DayOfWeek == DayOfWeek.Monday){
  //       thisWeek.WeekOf = weekDate;
  //     }
  //     else if(weekDate.DayOfWeek != DayOfWeek.Monday){
  //       if(weekDate.DayOfWeek == DayOfWeek.Tuesday)
  //       {thisWeek.WeekOf = weekDate.AddDays(6);}
  //       else if(weekDate.DayOfWeek == DayOfWeek.Wednesday)
  //       {thisWeek.WeekOf = weekDate.AddDays(5);}
  //       else if(weekDate.DayOfWeek == DayOfWeek.Thursday)
  //       {thisWeek.WeekOf = weekDate.AddDays(4);}
  //       else if(weekDate.DayOfWeek == DayOfWeek.Friday)
  //       {thisWeek.WeekOf = weekDate.AddDays(3);}
  //       else if(weekDate.DayOfWeek == DayOfWeek.Saturday)
  //       {thisWeek.WeekOf = weekDate.AddDays(2);}
  //       else
  //       {thisWeek.WeekOf = weekDate.AddDays(1);}
  //     }
  //     _db.RecipeWeeks.Add(thisWeek);
  //     _db.SaveChanges();
  //     Console.WriteLine(thisWeek.Week[0].Lunch.Title);
  //     return RedirectToAction("Index");
  //   }

  // public async Task<ActionResult> CreateDinner()
  //   {
  //     var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
  //     var currentUser = await _userManager.FindByIdAsync(userId);
  //     var userRecipes = _db.Recipes.Where(entry=> entry.User.Id==currentUser.Id).ToList();
  //     List<Recipe> UserDinner = new List<Recipe>{};

  //     foreach(Recipe recipe in userRecipes){
  //       if(recipe.isDinner){
  //         UserDinner.Add(recipe);
  //       }
  //     }
  //     if(userRecipes.Count == 0){
  //       return View(userRecipes);
  //     }
  //     else
  //     {
  //       List<Recipe> WeekDinner = Recipe.RandomDinners(UserDinner);
  //     return View(WeekDinner);
  //     }
  //   }

  // [HttpPost]
  //   public async Task<ActionResult> CreateDinner(List<Recipe> WeekDinner)
  //   {
  //     var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
  //     var currentUser = await _userManager.FindByIdAsync(userId);
  //     RecipeDay RecipeMonday = new RecipeDay(){DinnerRecipeId = WeekDinner[0].RecipeId,User = currentUser};
  //     _db.RecipeDays.Add(RecipeMonday);
  //     RecipeDay RecipeTuesday = new RecipeDay(){DinnerRecipeId = WeekDinner[1].RecipeId, User = currentUser};
  //     _db.RecipeDays.Add(RecipeTuesday);
  //     RecipeDay RecipeWednesday = new RecipeDay(){DinnerRecipeId = WeekDinner[2].RecipeId, User = currentUser};
  //     _db.RecipeDays.Add(RecipeWednesday);
  //     RecipeDay RecipeThursday = new RecipeDay(){DinnerRecipeId = WeekDinner[3].RecipeId, User = currentUser};
  //     _db.RecipeDays.Add(RecipeThursday);
  //     RecipeDay RecipeFriday = new RecipeDay(){DinnerRecipeId = WeekDinner[4].RecipeId, User = currentUser};
  //     _db.RecipeDays.Add(RecipeFriday);
  //     RecipeDay RecipeSaturday = new RecipeDay(){DinnerRecipeId = WeekDinner[5].RecipeId,User = currentUser};
  //     _db.RecipeDays.Add(RecipeSaturday);
  //     RecipeDay RecipeSunday = new RecipeDay(){DinnerRecipeId = WeekDinner[6].RecipeId, User = currentUser};
  //     _db.RecipeDays.Add(RecipeSunday);
  //     DateTime weekDate = DateTime.Now;
  //     RecipeWeek thisWeek = new RecipeWeek() { Week = new List<RecipeDay> { RecipeMonday, RecipeTuesday, RecipeWednesday, RecipeThursday, RecipeFriday, RecipeSaturday, RecipeSunday }, ApplicationUserId = currentUser.Id, DinnerPlan = true};
  //     if(weekDate.DayOfWeek == DayOfWeek.Monday){
  //       thisWeek.WeekOf = weekDate;
  //     }
  //     else if(weekDate.DayOfWeek != DayOfWeek.Monday){
  //       if(weekDate.DayOfWeek == DayOfWeek.Tuesday)
  //       {thisWeek.WeekOf = weekDate.AddDays(6);}
  //       else if(weekDate.DayOfWeek == DayOfWeek.Wednesday)
  //       {thisWeek.WeekOf = weekDate.AddDays(5);}
  //       else if(weekDate.DayOfWeek == DayOfWeek.Thursday)
  //       {thisWeek.WeekOf = weekDate.AddDays(4);}
  //       else if(weekDate.DayOfWeek == DayOfWeek.Friday)
  //       {thisWeek.WeekOf = weekDate.AddDays(3);}
  //       else if(weekDate.DayOfWeek == DayOfWeek.Saturday)
  //       {thisWeek.WeekOf = weekDate.AddDays(2);}
  //       else
  //       {thisWeek.WeekOf = weekDate.AddDays(1);}
  //     }
  //     _db.RecipeWeeks.Add(thisWeek);
  //     _db.SaveChanges();
  //     Console.WriteLine(thisWeek.Week[0].Dinner.Title);
  //     return RedirectToAction("Index");
  //   }
    public ActionResult Details(int id)
    {
      var thisMealPlan = _db.RecipeWeeks.FirstOrDefault(recipeWeek => recipeWeek.RecipeWeekId == id);
      return View(thisMealPlan);
    }

    public ActionResult Delete(int id)
    {
      var thisMealPlan = _db.RecipeWeeks.FirstOrDefault(recipeWeek => recipeWeek.RecipeWeekId == id);
      return View(thisMealPlan);
    }
    
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMealPlan = _db.RecipeWeeks.FirstOrDefault(recipeWeek => recipeWeek.RecipeWeekId == id);
      _db.RecipeWeeks.Remove(thisMealPlan);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}

// todo: add delete mealplan route

// todo: add a way for user to randomize single day
