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

namespace WhatsForDinner.Controllers
{
  [Authorize]
  public class RecipesController : Controller
  {
    private readonly WhatsForDinnerContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public RecipesController(UserManager<ApplicationUser> userManager, WhatsForDinnerContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userRecipes = _db.Recipes.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(userRecipes);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Recipe recipe)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      recipe.User = currentUser;
      _db.Recipes.Add(recipe);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public async Task<ActionResult> Calendar()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userRecipes = _db.Recipes.Where(entry => entry.User.Id == currentUser.Id).ToList();
      List<Recipe> UserBreakfast = Recipe.GetBreakfastRecipes(userRecipes);
      List<Recipe> UserLunch = Recipe.GetLunchRecipes(userRecipes);
      List<Recipe> UserDinner = Recipe.GetDinnerRecipes(userRecipes);
      List<Recipe> WeekBreakfast = Recipe.RandomBreakfasts(UserBreakfast);
      List<Recipe> WeekLunch = Recipe.RandomLunches(UserLunch);
      List<Recipe> WeekDinner = Recipe.RandomDinners(UserDinner);
      List<Recipe> WeekRecipes = Recipe.GetWeekPlan(WeekBreakfast, WeekLunch, WeekDinner);
      return View(WeekRecipes);
    }
  // how do I save this ^ Week of recipes in the Post?
    [HttpPost]
    public async Task<ActionResult> Calendar(Recipe recipe, List<Recipe> WeekRecipes)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      RecipeDay Monday = new RecipeDay(){DayName = "Monday", Breakfast = WeekRecipes[0], Lunch = WeekRecipes[7], Dinner = WeekRecipes[14]};
      _db.RecipeDays.Add(Monday);
      RecipeDay Tuesday = new RecipeDay(){DayName = "Tuesday", Breakfast = WeekRecipes[1], Lunch = WeekRecipes[8], Dinner = WeekRecipes[15]};
      _db.RecipeDays.Add(Tuesday);
      RecipeDay Wednesday = new RecipeDay(){DayName = "Wednesday", Breakfast = WeekRecipes[2], Lunch = WeekRecipes[9], Dinner = WeekRecipes[16]};
      _db.RecipeDays.Add(Wednesday);
      RecipeDay Thursday = new RecipeDay(){DayName = "Thursday", Breakfast = WeekRecipes[3], Lunch = WeekRecipes[10], Dinner = WeekRecipes[17]};
      _db.RecipeDays.Add(Thursday);
      RecipeDay Friday = new RecipeDay(){DayName = "Friday", Breakfast = WeekRecipes[4], Lunch = WeekRecipes[11], Dinner = WeekRecipes[18]};
      _db.RecipeDays.Add(Friday);
      RecipeDay Saturday = new RecipeDay(){DayName = "Saturday", Breakfast = WeekRecipes[5], Lunch = WeekRecipes[12], Dinner = WeekRecipes[19]};
      _db.RecipeDays.Add(Saturday);
      RecipeDay Sunday = new RecipeDay(){DayName = "Sunday", Breakfast = WeekRecipes[6], Lunch = WeekRecipes[13], Dinner = WeekRecipes[20]};
      _db.RecipeDays.Add(Sunday);
      RecipeWeek thisWeek = new RecipeWeek(){Week= new List<RecipeDay>{Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday}};
      _db.RecipeWeeks.Add(thisWeek);
      _db.ApplicationUserWeeks.Add(new ApplicationUserWeek(){RecipeWeek = thisWeek, ApplicationUserId = userId});
      _db.SaveChanges();
      Console.WriteLine(thisWeek.Week[5].Breakfast.Title);
      return RedirectToAction("Index");
    }
    //todo: add new controllers for calendars so these aren't getting saved over and over again
    // public ActionResult Import()
    // {
    //   return View();
    // }

    // [HttpPost]
    // public async Task<ActionResult> Import(Recipe recipe)
    // {
    //   var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    //   var currentUser = await _userManager.FindByIdAsync(userId);
    //   recipe.User = currentUser;
    //   _db.Recipes.Add(recipe);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
    public ActionResult Details(int id)
    {
      var thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);
    }
    public ActionResult Edit(int id)
    {
      var thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);
    }
    [HttpPost]
    public ActionResult Edit(Recipe recipe)
    {
      _db.Entry(recipe).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}