using BackendProject.Models;
using BackendProject.Repositories;
using Microsoft.AspNetCore.Mvc;

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
            if (isRegistered)
                return RedirectToAction("Login");

            ModelState.AddModelError("", "Bu e-posta ile kayıtlı bir kullanıcı zaten var.");
        }
        return View(user);
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await _userRepository.LoginUser(email, password);
        if (user != null)
        {
            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "Geçersiz e-posta veya şifre.");
        return View();
    }
}