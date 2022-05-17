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
      if(recipe.isBreakfast){
        _db.BreakfastRecipes.Add(new BreakfastRecipe(){Recipe = recipe});
      }
      else if(recipe.isLunch){
        _db.LunchRecipes.Add(new LunchRecipe(){Recipe = recipe});
      }
      else{
        _db.DinnerRecipes.Add(new DinnerRecipe(){Recipe = recipe});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Import()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Import(ImportedRecipe importedRecipe)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      importedRecipe.User = currentUser;
      var thisRecipe = ImportedRecipe.GetRecipe(EnvironmentVariables.apiKey, importedRecipe.sourceUrl);
      ImportedRecipe newRecipe = new ImportedRecipe(){title = thisRecipe.title, image = thisRecipe.image, User = currentUser, Breakfast = importedRecipe.Breakfast, Lunch = importedRecipe.Lunch, Dinner = importedRecipe.Dinner};
      _db.ImportedRecipes.Add(newRecipe);
      Recipe recipe = ImportedRecipe.ConvertToRecipe(newRecipe);
      _db.Recipes.Add(recipe);
      _db.SaveChanges();
      Console.WriteLine(thisRecipe.title);
      return RedirectToAction("Index");
    }
    // [HttpPost, ActionName("Import")]
    // public ActionResult ImportConfirmed(Recipe recipe)
    // {
    //   var thisRecipe = recipe;
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

    public ActionResult Delete(int id)
    {
      var thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      _db.Recipes.Remove(thisRecipe);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}