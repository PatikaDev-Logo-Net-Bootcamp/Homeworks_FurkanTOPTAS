using ApartmanYonetimOtomasyonu.Business.DTOs;
using ApartmanYonetimOtomasyonu.DataAccess.EntityFramework.Repository.Abstracts;
using ApartmanYonetimOtomasyonu.Domain.Entities;
using ApartmanYonetimOtomasyonu.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using static ApartmanYonetimOtomasyonu.Web.Areas.Identity.Pages.Account.ExternalLoginModel;

namespace ApartmanYonetimOtomasyonu.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        //private readonly RoleManager<IdentityRole> roleManager;
        

        public UserController(UserManager<User> userManager)
        {
            this.userManager = userManager;
            
        }
        [HttpGet]
        public async Task<IActionResult> Index() // Kullanıcıları Getir
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
                    PhoneNumber = user.PhoneNumber,
                    TCNo = user.TCNo,
                    CarLicensePlate = user.CarLicensePlate,
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



        [HttpGet]
        public IActionResult UpdateUser(string id)
        {
            var user = userManager.Users.FirstOrDefault(x => x.Id == id);
                        
            var userUpdate = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Id = user.Id,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                TCNo = user.TCNo,
                CarLicensePlate = user.CarLicensePlate,
                TypeOfUser = user.TypeOfUser
            };
            return View(userUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(User user)
        {
            User userUpdate = await userManager.FindByIdAsync(user.Id);
            MailAddress mail = new MailAddress(user.Email);
            
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            
            userUpdate.FirstName = user.FirstName;
            userUpdate.LastName = user.LastName;
            userUpdate.Email = user.Email;
            userUpdate.UserName = mail.User;
            userUpdate.PhoneNumber = user.PhoneNumber;
            userUpdate.TCNo = user.TCNo;
            userUpdate.CarLicensePlate = user.CarLicensePlate;
            userUpdate.TypeOfUser = user.TypeOfUser;

            var result= await userManager.UpdateAsync(userUpdate);
            if (result.Succeeded)
            {
                TempData["Message"] = "Güncelleme İşlemi Başarılı";
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteUser(string id) //Apartman Silme İşlemleri
        {
            var userDelete = await userManager.FindByIdAsync(id);
            var result = await userManager.DeleteAsync(userDelete);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(UserCreateDto user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            MailAddress mail = new MailAddress(user.Email);
            var userAdd = new User
            {
                UserName = mail.User,
                FirstName = user.FirstName,
                LastName = user.LastName,
                TCNo = user.TCNo,
                CarLicensePlate = user.CarLicensePlate,
                TypeOfUser = user.TypeOfUser,
                Email = user.Email,               
                PhoneNumber = user.PhoneNumber
            };
            var result = await userManager.CreateAsync(userAdd, user.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(userAdd, EntityFramework.Enums.Roles.BasicUser.ToString());
                TempData["Message"] = "Ekleme İşlemi Başarılı";
                return RedirectToAction("Index");
            }
            return View();

        }





    }
}
