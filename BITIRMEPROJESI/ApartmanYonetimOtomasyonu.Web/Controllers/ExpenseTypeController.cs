using ApartmanYonetimOtomasyonu.Business.Abstract;
using ApartmanYonetimOtomasyonu.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApartmanYonetimOtomasyonu.Web.Controllers
{
    [Authorize]
    public class ExpenseTypeController : Controller
    {
        private readonly IExpenseTypeService expenseTypeService;

        public ExpenseTypeController(IExpenseTypeService expenseTypeService)
        {
            this.expenseTypeService = expenseTypeService;
        }
        

        public IActionResult Index()
        {
            var model = expenseTypeService.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddExpenseType() //Apartman Ekleme Sayfası Çağırma
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddExpenseType(ExpenseType expenseType) // Apartman Ekleme İşlemleri
        {
            if (!ModelState.IsValid)
            {
                return View(expenseType);
            }
            expenseTypeService.Add(new ExpenseType
            {
                ExpenseTypeName = expenseType.ExpenseTypeName.ToUpper(),
                
            });
            TempData["Message"] = "Ekleme İşlemi Başarılı";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteExpenseType(int id) //Apartman Silme İşlemleri
        {
            var expenseType = expenseTypeService.GetById(id);
            expenseTypeService.Delete(expenseType);
            TempData["Message"] = "Silme İşlemi Başarılı";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateExpenseType(int id)
        {
            var expenseType = expenseTypeService.GetById(id);
            if (expenseType == null)
            {
                return RedirectToAction("Index");
            }
            return View(expenseType);
        }

        [HttpPost]
        public IActionResult UpdateExpenseType(ExpenseType expenseType)
        {
            if (!ModelState.IsValid)
            {
                return View(expenseType);
            }
            expenseTypeService.Update(expenseType);
            TempData["Message"] = "Güncelleme İşlemi Başarılı";
            return RedirectToAction("Index");
        }
    }
}
