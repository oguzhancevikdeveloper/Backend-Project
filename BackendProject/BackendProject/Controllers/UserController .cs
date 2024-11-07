using BackendProject.Models;
using BackendProject.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BackendProject.Controllers;

public class UserController(IUserRepository _userRepository) : Controller
{

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(User user)
    {
        if (ModelState.IsValid)
        {
            var isRegistered = await _userRepository.RegisterUser(user);
            if (isRegistered)return RedirectToAction("Login");
            ModelState.AddModelError("", "Bu e-posta ile kayıtlı bir kullanıcı zaten var.");
        }
        return View(user);
    }

    public IActionResult Login(){return View();}

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await _userRepository.LoginUser(email, password);
        if (user != null)
        {

            // Kullanıcıyı kimlik doğrulaması için oturum açtırma
            var claims = new List<Claim> {new Claim(user.Name, user.Email)};
            var identity = new ClaimsIdentity(claims, "Cookies");
            var principal = new ClaimsPrincipal(identity);


            await HttpContext.SignInAsync("Cookies", principal);
            return RedirectToAction("Index", "FormManagement");
        }

        ModelState.AddModelError("", "Geçersiz e-posta veya şifre.");
        return View();
    }
}