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
    [Authorize(Roles ="Admin")] //only Admin person come in Here
    public class AdminController : Controller
    {
        private readonly UserManager<UserApplication> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(UserManager<UserApplication> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {

            return View();
        }



        public IActionResult UserList()
        {

            return View(_userManager.Users.ToList());
        }
        public async Task<IActionResult> Details(string id)
        {
            UserApplication userFound = await _userManager.FindByIdAsync(id);

            if (userFound == null)
            {
                return RedirectToAction(nameof(UserList));
            }
            return View(userFound);
        }


        public async Task<IActionResult> RolesManagment(string id)
        {
            UserApplication userFound = await _userManager.FindByIdAsync(id);

            if (userFound == null)
            {
                return RedirectToAction(nameof(UserList));
            }

            IList<string> UserRoles = await _userManager.GetRolesAsync(userFound);
            List<IdentityRole> IdentityRole = _roleManager.Roles.ToList();

            RolesManagmentViewModel RviewModel = new RolesManagmentViewModel(id, UserRoles, IdentityRole);
            return View(RviewModel);
        }
        public async Task<IActionResult> AddRoleToUser(string userId, string roleName)
        {

            UserApplication userFound = await _userManager.FindByIdAsync(userId);

            if (userFound == null)
            {
                return RedirectToAction(nameof(UserList));
            }
            var result = await _userManager.AddToRoleAsync(userFound, roleName);
            if (result.Succeeded)
            {
                return RedirectToAction("RolesManagment", new {id= userId });
            }

            IList<string> UserRoles = await _userManager.GetRolesAsync(userFound);
            List<IdentityRole> IdentityRole = _roleManager.Roles.ToList();

            RolesManagmentViewModel RviewModel = new RolesManagmentViewModel(userId, UserRoles, IdentityRole);
            ViewBag.ErroMsg = "Failed to change role for user";
            return View("RolesManagment", RviewModel);
        }

        //Remove
        public async Task<IActionResult> RemoveRoleFromUser(string userId, string roleName)
        {

            UserApplication userFound = await _userManager.FindByIdAsync(userId);

            if (userFound == null)
            {
                return RedirectToAction(nameof(UserList));
            }
            var result = await _userManager.RemoveFromRoleAsync(userFound, roleName);
            if (result.Succeeded)
            {
                return RedirectToAction("RolesManagment", new { id = userId });
            }
            IList<string> UserRoles = await _userManager.GetRolesAsync(userFound);
            List<IdentityRole> IdentityRole = _roleManager.Roles.ToList();

            RolesManagmentViewModel RviewModel = new RolesManagmentViewModel(userId, UserRoles, IdentityRole);
            ViewBag.ErroMsg = "Failed to change role for user";
            return View("RolesManagment", RviewModel);
        }

        public IActionResult RoleList()
        {

            return View(_roleManager.Roles.ToList());
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)

        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                ViewBag.ErroMsg = "Role Name need to be long and not onyly blak";

                return View("CreateRole", roleName);
            }

            IdentityRole role = new IdentityRole(roleName );

            var restult = await _roleManager.CreateAsync(role);

            if (restult.Succeeded)
            {
       return RedirectToAction(nameof(RoleList));
            }
            ViewBag.ErroMsg = "Role was not created";

            return View("CreateRole", roleName);
        }

        //RemoveR
  
        public async Task<IActionResult> RemoveRole(string roleName)

        {
            //if (string.IsNullOrWhiteSpace(roleName))
            //{
            //    return RedirectToAction(nameof(RoleList));
            //}

            if (!string.IsNullOrWhiteSpace(roleName) &&
            await _roleManager.RoleExistsAsync(roleName))
            {
                IdentityRole role = await _roleManager.FindByNameAsync(roleName);
                var result = await _roleManager.DeleteAsync(role);
            }


            return RedirectToAction(nameof(RoleList));

        }
    }
}