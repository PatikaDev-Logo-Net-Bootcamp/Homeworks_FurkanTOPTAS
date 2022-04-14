using ApartmanYonetimOtomasyonu.Business.Abstract;
using ApartmanYonetimOtomasyonu.Business.DTOs;
using ApartmanYonetimOtomasyonu.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Web.Controllers
{
    public class ExpenseController : Controller
    {
        //[AuthorizeByRole(Roles="Admin")]

        private readonly IExpenseService expenseService;
        private readonly IExpenseTypeService expenseTypeService;
        private readonly IFlatService flatService;

        public ExpenseController(IExpenseService expenseService, IExpenseTypeService expenseTypeService, IFlatService flatService)
        {
            this.expenseService = expenseService;
            this.expenseTypeService = expenseTypeService;
            this.flatService = flatService;
        }

        [HttpGet]
        public async Task<IActionResult> Index() // Daire Listeleme
        
        {
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
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteExpense(int id) //Apartman Silme İşlemleri
        {
            var expense = expenseService.GetById(id);
            expenseService.Delete(expense);
            return RedirectToAction("Index");
        }

    }
}
