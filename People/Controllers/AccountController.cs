using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using People.Models;
using People.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Controllers
{
    public class AccountController : Controller

    {
        private readonly UserManager<UserApplication> _userManager;
        private readonly SignInManager<UserApplication> _signInManager;

        public AccountController(UserManager<UserApplication> userManager,
            SignInManager<UserApplication> signInManager) // Constructor Injection
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterViewModel userRegister)
        {

            if (ModelState.IsValid)
            {
                UserApplication user = new UserApplication()
                {
                    UserName = userRegister.UserName,
                    Email = userRegister.Email,
                    PhoneNumber = userRegister.Phone,
                    FirstName = userRegister.FirstName,
                    LastName = userRegister.LastName,
                    BirthDate = userRegister.BirthDate
                };

                IdentityResult result = await _userManager.CreateAsync(user, userRegister.Password);
                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Home");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
            }
            return View(userRegister);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginUser)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(loginUser.UserName, loginUser.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("Lock-out", "Too many login attemt");
                }
            }
            return View(loginUser);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
           await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
    }
