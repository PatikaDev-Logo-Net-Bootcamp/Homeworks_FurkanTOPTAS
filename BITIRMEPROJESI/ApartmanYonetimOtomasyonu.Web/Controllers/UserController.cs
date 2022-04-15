using ApartmanYonetimOtomasyonu.Domain.Entities;
using ApartmanYonetimOtomasyonu.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();
            var userRoleViewModel = new List<UserRolesViewModel>();
            foreach (User user in users)
            {
                var thisViewModel = new UserRolesViewModel
                {
                    UserId = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Roles = await GetUserRoles(user)
                };
                userRoleViewModel.Add(thisViewModel);
            }
            return View(userRoleViewModel);
        }

        private async Task<List<string>> GetUserRoles(User user)
        {
            return new List<string>(await userManager.GetRolesAsync(user));
        }
    }
}
