﻿using ApartmanYonetimOtomasyonu.Business.Abstract;
using ApartmanYonetimOtomasyonu.Business.DTOs;
using ApartmanYonetimOtomasyonu.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Web.Controllers
{
    public class FlatController : Controller
    {
        //[AuthorizeByRole(Roles="Admin")]

        private readonly IFlatService flatService;
        private readonly UserManager<User> userManager;
        private readonly IBuildingService buildingService;

        public FlatController(IFlatService flatService, UserManager<User> userManager, IBuildingService buildingService)
        {
            this.flatService = flatService;
            this.userManager = userManager;
            this.buildingService = buildingService;
        }

        [HttpGet]
        public async Task<IActionResult> Index() // Daire Listeleme
        {
            var flats = await flatService.GetAllFlatsByRelations();
            return View(flats);           
        }

        [HttpGet]
        public IActionResult AddFlat() // Daire Ekleme
        {
            var users = userManager.Users.ToList();
            var building = buildingService.GetAll();
            var flat = new FlatCreateDto
            {
                Buildings = building,
                Users = users,
            };
            return View(flat);
        }
        [HttpPost]
        public IActionResult AddFlat(FlatCreateDto flat) // Daire Ekleme
        {
            if (!ModelState.IsValid)
            {
                return View(flat);
            }
            flatService.Add(new Flat
            {
                UserId = flat.UserId,
                BuildingId = flat.BuildingId,
                FlatNo = flat.FlatNo,
                IsEmpty = flat.IsEmpty,
                IsDeleted = false,
                Floor = flat.Floor,
                RoomSize = flat.RoomSize,
                SaloonSize = flat.SaloonSize,
            });
            return RedirectToAction("Index");
        }

    }
}