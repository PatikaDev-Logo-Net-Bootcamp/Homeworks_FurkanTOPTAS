using ApartmanYonetimOtomasyonu.Business.Abstract;
using ApartmanYonetimOtomasyonu.Business.DTOs;
using ApartmanYonetimOtomasyonu.Domain.Entities;
using ApartmanYonetimOtomasyonu.EntityFramework.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Web.Controllers
{

    [Authorize]

    public class ExpenseController : Controller
    {
       

        private readonly IExpenseService expenseService;
        private readonly IExpenseTypeService expenseTypeService;
        private readonly IFlatService flatService;
        private readonly IBuildingService buildingService;
        private readonly IPaymentService paymentService;
        private readonly UserManager<User> userManager;

        public ExpenseController(IExpenseService expenseService, IExpenseTypeService expenseTypeService, IFlatService flatService, IBuildingService buildingService, IPaymentService paymentService, UserManager<User> userManager)
        {
            this.expenseService = expenseService;
            this.expenseTypeService = expenseTypeService;
            this.flatService = flatService;
            this.buildingService = buildingService;
            this.paymentService = paymentService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index() // Daire Listeleme
        {

                var userRole = await userManager.GetRolesAsync(await userManager.GetUserAsync(User));
                if (userRole[0] == "BasicUser")
                {
                    var id = userManager.GetUserId(User);
                    var flat = flatService.GetAll().Where(x => x.UserId == id).FirstOrDefault();

                //var nonPaidExpense = expenseService.GetAllExpenseByRelations().Result.Where(x => x.IsPaid == false).ToList();
                //var paidExpense = expenseService.GetAllExpenseByRelations().Result.Where(x => x.IsPaid == true).ToList();
                // && x.IsPaid == false

                var expenseForBasicUser = expenseService.GetAllExpenseByRelations().Result.Where(x => x.FlatId == flat.Id).ToList();
                    return View(expenseForBasicUser);
                }
            var expense = await expenseService.GetAllExpenseByRelations();
            return View(expense);
        }

        [HttpGet]
        public IActionResult AddExpense() // Daire Ekleme
        {
            var expenseType = expenseTypeService.GetAll();
            var flat = flatService.GetAll();
            var expense = new ExpenseCreateDto
            {
                ExpenseType = expenseType,
                Flat = flat
            };
            return View(expense);
        }
        [HttpPost]
        public IActionResult AddExpense(ExpenseDto expense) // Daire Ekleme
        {
            if (!ModelState.IsValid)
            {
                return View(expense);
            }
            expenseService.Add(new Expense
            {
                FlatId = expense.FlatId,
                ExpenseTypeId = expense.ExpenseTypeId,

                InvoiceDate = DateTime.Now,
                IsPaid = expense.IsPaid,
                Price = expense.Price,
            });
            TempData["Message"] = "Ekleme İşlemi Başarılı";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateExpense(int id)
        {
            var expenseType = expenseTypeService.GetAll();
            var flat = flatService.GetAll();
            var expense = expenseService.GetById(id);

            var expenseUpdate = new ExpenseCreateDto
            {
                FlatId = expense.FlatId,
                ExpenseTypeId = expense.ExpenseTypeId,
                Id = expense.Id,
                InvoiceDate = expense.InvoiceDate,
                IsPaid = expense.IsPaid,
                Price = expense.Price,
                ExpenseType = expenseType,
                Flat = flat
            };
            return View(expenseUpdate);
        }

        [HttpPost]
        public IActionResult UpdateExpense(ExpenseCreateDto expense)
        {
            var expenseType = expenseTypeService.GetAll();
            var flat = flatService.GetAll();

            if (!ModelState.IsValid)
            {
                return View(expense);
            }
            expenseService.Update(new Expense
            {

                FlatId = expense.FlatId,
                ExpenseTypeId = expense.ExpenseTypeId,
                Id = expense.Id,
                InvoiceDate = DateTime.Now,
                IsPaid = expense.IsPaid,
                Price = expense.Price,
            });
            TempData["Message"] = "Güncelleme İşlemi Başarılı";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteExpense(int id) //Apartman Silme İşlemleri
        {
            var expense = expenseService.GetById(id);
            expenseService.Delete(expense);
            TempData["Message"] = "Silme İşlemi Başarılı";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddAllFlatExpense() // Daire Ekleme
        {
            var expenseType = expenseTypeService.GetAll();
            var flat = flatService.GetAll();
            var building = buildingService.GetAll();
            var expense = new ExpenseCreateDto
            {
                ExpenseType = expenseType,
                Building = building,
                // Flat = flat
            };
            return View(expense);
        }
        [HttpPost]
        public IActionResult AddAllFlatExpense(ExpenseCreateDto expense) // Daire Ekleme
        {
            if (!ModelState.IsValid)
            {
                return View(expense);
            }
            expenseService.AddAllFlatsExpense(expense);
            TempData["Message"] = "Toplu Gider Ekleme İşlemi Başarılı";
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult PaymentCreate(int id)
        {
            var expense = expenseService.GetById(id);
            var CreatePayment = new PaymentCreateDto
            {
                ExpenseId = expense.Id,
                FlatId = expense.FlatId,
                InvoiceAmount = expense.Price
            };
            return View(CreatePayment);

        }

        [HttpPost]
        public async Task<IActionResult> PaymentCreate(PaymentCreateDto createPaymentDto)
        {
            var paidExpense = expenseService.GetById(createPaymentDto.ExpenseId);
            
            createPaymentDto.InvoiceAmount = paidExpense.Price;
            createPaymentDto.FlatId = paidExpense.FlatId;
            createPaymentDto.ExpenseId = paidExpense.Id;
            var response = await paymentService.PaymentCreate(createPaymentDto);
            
            if (response.StatusCode == StatusCodes.Status200OK)
            {
                paidExpense.IsPaid = true;
                expenseService.Update(paidExpense);
                TempData["Message"] = "Ödeme Başarılı";

                return RedirectToAction("Index");
            }
          //  TempData.Add("message", response.Message);
            return RedirectToAction("Index");
        }

        

    }
}
