using ApartmanYonetimOtomasyonu.Business.Abstract;
using ApartmanYonetimOtomasyonu.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Web.Controllers
{
    [Authorize]
    public class BuildingController : Controller
    {
        private readonly IBuildingService buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            this.buildingService = buildingService;
        }
        
        [HttpGet]
        public IActionResult Get()//Apartman Listeleme
        {
            var result = buildingService.GetAll();
            return View(result);
        }
        
        [HttpGet]
        public IActionResult AddBuilding() //Apartman Ekleme Sayfası Çağırma
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBuilding(Building building) // Apartman Ekleme İşlemleri
        {
            if (!ModelState.IsValid)
            {
                return View(building);
            }
            buildingService.Add(new Building
            {
                BuildingName = building.BuildingName.ToUpper(),
                TotalFloor = building.TotalFloor,
                TotalFlat = building.TotalFlat,
            });
            return RedirectToAction("Get");  
        }

        [HttpGet]
        public IActionResult DeleteBuilding(int id) //Apartman Silme İşlemleri
        {
            var building = buildingService.GetById(id);
            buildingService.Delete(building);
            return RedirectToAction("Get");
        }

        [HttpGet]
        public IActionResult UpdateBuilding(int id)
        {
            var building = buildingService.GetById(id);
            if (building == null)
            {
                return RedirectToAction("Get");
            }
            return View(building);
        }

        [HttpPost]
        public IActionResult UpdateBuilding(Building building)
        {
            if (!ModelState.IsValid)
            {
                return View(building);
            }
            buildingService.Update(building);
            return RedirectToAction("Get");
        }

    }
}
