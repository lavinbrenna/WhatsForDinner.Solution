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
  public class RecipesController: Controller
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
  public async Task<ActionResult> Calendar(){
    var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    var currentUser = await _userManager.FindByIdAsync(userId);
    var userRecipes = _db.Recipes.Where(entry => entry.User.Id == currentUser.Id).ToList();
    List<Recipe> CalendarRecipes = new List<Recipe>{};
    List<Recipe> WeekBreakfast = new List<Recipe>{};
    List<Recipe> WeekLunch = new List<Recipe>{};
    List<Recipe> WeekDinner = new List<Recipe>{};
    Random rnd = new Random();
    while(WeekBreakfast.Count != 7){
      int random = rnd.Next(0, userRecipes.Count);
      if(!WeekBreakfast.Contains(userRecipes[random]) && userRecipes[random].isBreakfast)
      {
        WeekBreakfast.Add(userRecipes[random]);
      }
      else if(WeekBreakfast.Contains(userRecipes[random]) && userRecipes[random].isBreakfast)
      {
        if(userRecipes[random].MinFrequency < 7 && userRecipes[random].MinFrequency <= 4){
          WeekBreakfast.Add(userRecipes[random]);
        }
      }
    }
    Console.WriteLine(WeekBreakfast[0].Title);
    while(WeekLunch.Count != 7){
      int random = rnd.Next(0, userRecipes.Count);
      if(!WeekLunch.Contains(userRecipes[random]) && userRecipes[random].isLunch)
      {
        WeekLunch.Add(userRecipes[random]);
      }
      else if(WeekLunch.Contains(userRecipes[random]) && userRecipes[random].isLunch)
      {
        if(userRecipes[random].MinFrequency < 7 && userRecipes[random].MinFrequency <= 3){
          WeekLunch.Add(userRecipes[random]);
        }
      }
    }
    Console.WriteLine(WeekLunch[0].Title);

    while(WeekDinner.Count != 7){
      int random = rnd.Next(0, userRecipes.Count);
      if(!WeekDinner.Contains(userRecipes[random]) && userRecipes[random].isDinner)
      {
        WeekDinner.Add(userRecipes[random]);
      }
    }
    Console.WriteLine(WeekDinner[0].Title);
    foreach(Recipe recipe in WeekBreakfast){
      CalendarRecipes.Add(recipe);
    }
    foreach(Recipe recipe in WeekLunch){
      CalendarRecipes.Add(recipe);
    }
    foreach(Recipe recipe in WeekDinner){
      CalendarRecipes.Add(recipe);
    }
    return View(CalendarRecipes);
    //add an option to save this list as a new userRecipe list (recipeWeeklist or something);
  }
  [HttpPost]
  public async Task<ActionResult> Calendar(List<Recipe> Recipes, int UserCalendarId)
  {
    var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    var currentUser = await _userManager.FindByIdAsync(userId);
    // userCalendar.User = currentUser;
    // _db.UserCalendars.Add();
    // _db.SaveChanges();
    return RedirectToAction("Index");
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

    public ActionResult Import()
    {
      return View();
    }

[HttpPost]
public async Task<ActionResult> Import(Recipe recipe)
{
  var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
  var currentUser = await _userManager.FindByIdAsync(userId);
  recipe.User = currentUser;
  _db.Recipes.Add(recipe);
  _db.SaveChanges();
  return RedirectToAction("Index");
}
    public ActionResult Details(int id)
    {
      var thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);
    }
    public ActionResult Edit(int id)
    {
      var thisRecipe = _db.Recipes.FirstOrDefault(recipe=> recipe.RecipeId == id);
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