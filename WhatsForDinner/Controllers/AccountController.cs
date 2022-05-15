using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WhatsForDinner.Models;
using System.Threading.Tasks;
using WhatsForDinner.ViewModels;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System;
namespace WhatsForDinner.Controllers
{
  public class AccountController : Controller
  {
    private readonly WhatsForDinnerContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, WhatsForDinnerContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }
    public async Task<ActionResult> Index(string id)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      List<ApplicationUserWeek> userWeeks = _db.ApplicationUserWeeks.Where(m => m.User.Id == userId).ToList();
      return View(userWeeks);
    }

    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
      var user = new ApplicationUser {UserName = model.Email};
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
      if(result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }

    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]

    public async Task<ActionResult> Login(LoginViewModel model)
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
      if(result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }

    [HttpPost]
    public async Task<ActionResult> LogOff()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index", "Home");
    }
  }
}