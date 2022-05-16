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
      var userCalendars = _db.ApplicationUserWeeks.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(userCalendars);
    }
    public async Task<ActionResult> Create()
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
    public async Task<ActionResult> Create(List<Recipe> WeekRecipes)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      RecipeDay RecipeMonday = new RecipeDay(){Breakfast = WeekRecipes[0], Lunch = WeekRecipes[7], Dinner = WeekRecipes[14], User = currentUser};
      _db.RecipeDays.Add(RecipeMonday);
      RecipeDay RecipeTuesday = new RecipeDay(){Breakfast = WeekRecipes[1], Lunch = WeekRecipes[8], Dinner = WeekRecipes[15], User = currentUser};
      _db.RecipeDays.Add(RecipeTuesday);
      RecipeDay RecipeWednesday = new RecipeDay(){Breakfast = WeekRecipes[2], Lunch = WeekRecipes[9], Dinner = WeekRecipes[16], User = currentUser};
      _db.RecipeDays.Add(RecipeWednesday);
      RecipeDay RecipeThursday = new RecipeDay(){Breakfast = WeekRecipes[3], Lunch = WeekRecipes[10], Dinner = WeekRecipes[17], User = currentUser};
      _db.RecipeDays.Add(RecipeThursday);
      RecipeDay RecipeFriday = new RecipeDay(){Breakfast = WeekRecipes[4], Lunch = WeekRecipes[11], Dinner = WeekRecipes[18], User = currentUser};
      _db.RecipeDays.Add(RecipeFriday);
      RecipeDay RecipeSaturday = new RecipeDay(){Breakfast = WeekRecipes[5], Lunch = WeekRecipes[12], Dinner = WeekRecipes[19], User = currentUser};
      _db.RecipeDays.Add(RecipeSaturday);
      RecipeDay RecipeSunday = new RecipeDay(){Breakfast = WeekRecipes[6], Lunch = WeekRecipes[13], Dinner = WeekRecipes[20], User = currentUser};
      _db.RecipeDays.Add(RecipeSunday);
      DateTime weekDate = DateTime.Now;
      RecipeWeek thisWeek = new RecipeWeek() { Week = new List<RecipeDay> { RecipeMonday, RecipeTuesday, RecipeWednesday, RecipeThursday, RecipeFriday, RecipeSaturday, RecipeSunday }, ApplicationUserId = currentUser.Id};
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
      _db.ApplicationUserWeeks.Add(new ApplicationUserWeek() { RecipeWeek = thisWeek, ApplicationUserId = currentUser.Id });
      _db.SaveChanges();
      Console.WriteLine(thisWeek.Week[0].Breakfast.RecipeId);
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisMealPlan = _db.ApplicationUserWeeks.FirstOrDefault(applicationUserWeek => applicationUserWeek.ApplicationUserWeekId == id);
      return View(thisMealPlan);
    }
  }
}

// todo: add delete mealplan route
// todo: add routes for just breakfast, just lunch, just dinner or all three meals randomizing.
// todo: add a way for user to randomize single day
