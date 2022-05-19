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

    public ActionResult Create()
    {
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
      else
      {
        List<Recipe> WeekBreakfast = Recipe.RandomBreakfasts(UserBreakfast);
        List<Recipe> WeekLunch = Recipe.RandomLunches(UserLunch);
        List<Recipe> WeekDinner = Recipe.RandomDinners(UserDinner);
        List<Recipe> WeeklyRecipes = Recipe.GetWeekPlan(WeekBreakfast, WeekLunch, WeekDinner);
        return View(WeeklyRecipes);
      }
    }

    [HttpPost]
    public async Task<ActionResult> CreateAll(List<Recipe> WeeklyRecipes)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      RecipeDay RecipeMonday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[0].RecipeId, LunchRecipeId = WeeklyRecipes[7].RecipeId, DinnerRecipeId = WeeklyRecipes[14].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeMonday);
      RecipeDay RecipeTuesday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[1].RecipeId, LunchRecipeId = WeeklyRecipes[8].RecipeId, DinnerRecipeId = WeeklyRecipes[15].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeTuesday);
      RecipeDay RecipeWednesday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[2].RecipeId, LunchRecipeId = WeeklyRecipes[9].RecipeId, DinnerRecipeId = WeeklyRecipes[16].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeWednesday);
      RecipeDay RecipeThursday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[3].RecipeId, LunchRecipeId = WeeklyRecipes[10].RecipeId, DinnerRecipeId = WeeklyRecipes[17].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeThursday);
      RecipeDay RecipeFriday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[4].RecipeId, LunchRecipeId = WeeklyRecipes[11].RecipeId, DinnerRecipeId = WeeklyRecipes[18].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeFriday);
      RecipeDay RecipeSaturday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[5].RecipeId, LunchRecipeId = WeeklyRecipes[12].RecipeId, DinnerRecipeId = WeeklyRecipes[19].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeSaturday);
      RecipeDay RecipeSunday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[6].RecipeId, LunchRecipeId = WeeklyRecipes[13].RecipeId, DinnerRecipeId = WeeklyRecipes[20].RecipeId, User = currentUser};
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
      return RedirectToAction("Index");
    }

    public async Task<ActionResult> CreateBreakfast()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userRecipes = _db.Recipes.Where(entry=> entry.User.Id==currentUser.Id).ToList();
      List<Recipe> UserBreakfast = new List<Recipe>{};
      // List<Recipe> UserLunch = new List<Recipe>{};
      // List<Recipe> UserDinner = new List<Recipe>{};
      foreach(Recipe recipe in userRecipes){
        if(recipe.isBreakfast){
          UserBreakfast.Add(recipe);
        }
      }
      if(userRecipes.Count == 0){
        return View(userRecipes);
      }
      else
      {
        List<Recipe> WeeklyRecipes = Recipe.RandomBreakfasts(UserBreakfast);
        return View(WeeklyRecipes);
      }
    }

[HttpPost]
    public async Task<ActionResult> CreateBreakfast(List<Recipe> WeeklyRecipes)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      RecipeDay RecipeMonday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[0].RecipeId, LunchRecipeId = WeeklyRecipes[0].RecipeId, DinnerRecipeId = WeeklyRecipes[0].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeMonday);
      RecipeDay RecipeTuesday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[1].RecipeId, LunchRecipeId = WeeklyRecipes[1].RecipeId, DinnerRecipeId = WeeklyRecipes[1].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeTuesday);
      RecipeDay RecipeWednesday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[2].RecipeId, LunchRecipeId = WeeklyRecipes[2].RecipeId, DinnerRecipeId = WeeklyRecipes[2].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeWednesday);
      RecipeDay RecipeThursday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[3].RecipeId, LunchRecipeId = WeeklyRecipes[3].RecipeId, DinnerRecipeId = WeeklyRecipes[3].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeThursday);
      RecipeDay RecipeFriday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[4].RecipeId, LunchRecipeId = WeeklyRecipes[4].RecipeId, DinnerRecipeId = WeeklyRecipes[4].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeFriday);
      RecipeDay RecipeSaturday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[5].RecipeId, LunchRecipeId = WeeklyRecipes[5].RecipeId, DinnerRecipeId = WeeklyRecipes[5].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeSaturday);
      RecipeDay RecipeSunday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[6].RecipeId, LunchRecipeId = WeeklyRecipes[6].RecipeId, DinnerRecipeId = WeeklyRecipes[6].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeSunday);
      DateTime weekDate = DateTime.Now;
      RecipeWeek thisWeek = new RecipeWeek() { Week = new List<RecipeDay> { RecipeMonday, RecipeTuesday, RecipeWednesday, RecipeThursday, RecipeFriday, RecipeSaturday, RecipeSunday }, ApplicationUserId = currentUser.Id, BreakfastPlan = true};
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
      return RedirectToAction("Index");
    }
      public async Task<ActionResult> CreateLunch()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userRecipes = _db.Recipes.Where(entry=> entry.User.Id==currentUser.Id).ToList();
      List<Recipe> UserLunch = new List<Recipe>{};

      foreach(Recipe recipe in userRecipes){
        if(recipe.isLunch){
          UserLunch.Add(recipe);
        }
      }
      if(userRecipes.Count == 0){
        return View(userRecipes);
      }
      else
      {
        List<Recipe> WeeklyRecipes = Recipe.RandomLunches(UserLunch);
        return View(WeeklyRecipes);
      }
    }

[HttpPost]
    public async Task<ActionResult> CreateLunch(List<Recipe> WeeklyRecipes)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      RecipeDay RecipeMonday = new RecipeDay(){ BreakfastRecipeId = WeeklyRecipes[0].RecipeId, LunchRecipeId = WeeklyRecipes[0].RecipeId, DinnerRecipeId = WeeklyRecipes[0].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeMonday);
      RecipeDay RecipeTuesday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[1].RecipeId, LunchRecipeId = WeeklyRecipes[1].RecipeId, DinnerRecipeId = WeeklyRecipes[1].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeTuesday);
      RecipeDay RecipeWednesday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[2].RecipeId, LunchRecipeId = WeeklyRecipes[2].RecipeId, DinnerRecipeId = WeeklyRecipes[2].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeWednesday);
      RecipeDay RecipeThursday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[3].RecipeId, LunchRecipeId = WeeklyRecipes[3].RecipeId, DinnerRecipeId = WeeklyRecipes[3].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeThursday);
      RecipeDay RecipeFriday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[4].RecipeId, LunchRecipeId = WeeklyRecipes[4].RecipeId, DinnerRecipeId = WeeklyRecipes[4].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeFriday);
      RecipeDay RecipeSaturday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[5].RecipeId, LunchRecipeId = WeeklyRecipes[5].RecipeId, DinnerRecipeId = WeeklyRecipes[5].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeSaturday);
      RecipeDay RecipeSunday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[6].RecipeId, LunchRecipeId = WeeklyRecipes[6].RecipeId, DinnerRecipeId = WeeklyRecipes[6].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeSunday);
      DateTime weekDate = DateTime.Now;
      RecipeWeek thisWeek = new RecipeWeek() { Week = new List<RecipeDay> { RecipeMonday, RecipeTuesday, RecipeWednesday, RecipeThursday, RecipeFriday, RecipeSaturday, RecipeSunday }, ApplicationUserId = currentUser.Id, LunchPlan = true};
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
      return RedirectToAction("Index");
    }

      public async Task<ActionResult> CreateDinner()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userRecipes = _db.Recipes.Where(entry=> entry.User.Id==currentUser.Id).ToList();
      List<Recipe> UserDinner = new List<Recipe>{};
      foreach(Recipe recipe in userRecipes){
        if(recipe.isDinner){
          UserDinner.Add(recipe);
        }
      }
      if(userRecipes.Count == 0){
        return View(userRecipes);
      }
      else
      {
        List<Recipe> WeeklyRecipes = Recipe.RandomDinners(UserDinner);
        return View(WeeklyRecipes);
      }
    }

[HttpPost]
    public async Task<ActionResult> CreateDinner(List<Recipe> WeeklyRecipes)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      RecipeDay RecipeMonday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[0].RecipeId, LunchRecipeId = WeeklyRecipes[0].RecipeId, DinnerRecipeId = WeeklyRecipes[0].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeMonday);
      RecipeDay RecipeTuesday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[1].RecipeId, LunchRecipeId = WeeklyRecipes[1].RecipeId, DinnerRecipeId = WeeklyRecipes[1].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeTuesday);
      RecipeDay RecipeWednesday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[2].RecipeId, LunchRecipeId = WeeklyRecipes[2].RecipeId, DinnerRecipeId = WeeklyRecipes[2].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeWednesday);
      RecipeDay RecipeThursday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[3].RecipeId, LunchRecipeId = WeeklyRecipes[3].RecipeId, DinnerRecipeId = WeeklyRecipes[3].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeThursday);
      RecipeDay RecipeFriday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[4].RecipeId, LunchRecipeId = WeeklyRecipes[4].RecipeId, DinnerRecipeId = WeeklyRecipes[4].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeFriday);
      RecipeDay RecipeSaturday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[5].RecipeId, LunchRecipeId = WeeklyRecipes[5].RecipeId, DinnerRecipeId = WeeklyRecipes[5].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeSaturday);
      RecipeDay RecipeSunday = new RecipeDay(){BreakfastRecipeId = WeeklyRecipes[6].RecipeId, LunchRecipeId = WeeklyRecipes[6].RecipeId, DinnerRecipeId = WeeklyRecipes[6].RecipeId, User = currentUser};
      _db.RecipeDays.Add(RecipeSunday);
      DateTime weekDate = DateTime.Now;
      RecipeWeek thisWeek = new RecipeWeek() { Week = new List<RecipeDay> { RecipeMonday, RecipeTuesday, RecipeWednesday, RecipeThursday, RecipeFriday, RecipeSaturday, RecipeSunday }, ApplicationUserId = currentUser.Id, DinnerPlan = true};
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
      return RedirectToAction("Index");
    }
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
      foreach(RecipeDay recipeDay in thisMealPlan.Week)
      {
        _db.RecipeDays.Remove(recipeDay);
      }
      _db.RecipeWeeks.Remove(thisMealPlan);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}

