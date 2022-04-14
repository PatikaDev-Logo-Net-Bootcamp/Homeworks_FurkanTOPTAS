using ApartmanYonetimOtomasyonu.Business.Abstract;
using ApartmanYonetimOtomasyonu.Business.DTOs;
using ApartmanYonetimOtomasyonu.DataAccess.EntityFramework.Repository.Abstracts;
using ApartmanYonetimOtomasyonu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Business.Concretes
{
    public class ExpenseService : IExpenseService
    {
        private readonly IRepository<Expense> repository;
        private readonly IExpenseRepository expenseRepository;
        private readonly IUnitOfWork unitOfWork;

        public ExpenseService(IRepository<Expense> repository, IExpenseRepository expenseRepository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.expenseRepository = expenseRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Add(Expense expense)
        {
            repository.Add(expense);
            unitOfWork.Commit();
        }

        public void Delete(Expense expense)
        {
            var exitExpense = repository.Get().FirstOrDefault(x => x.Id == expense.Id);
            if (exitExpense != null)
            {
                exitExpense.IsDeleted = true;
                repository.Update(exitExpense);
                unitOfWork.Commit();
            }
        }

        public List<Expense> GetAll()
        {
            return repository.Get().ToList();
        }

        public Expense GetById(int Id)
        {
            return repository.Get().FirstOrDefault(x => x.Id == Id);
        }

        public void Update(Expense expense)
        {
            var exitExpense = repository.Get().FirstOrDefault(x => x.Id == expense.Id);
            if (exitExpense != null)
            {
                
                exitExpense.Price = !string.IsNullOrEmpty(expense.Price.ToString()) ? expense.Price : exitExpense.Price;
                exitExpense.IsPaid = !string.IsNullOrEmpty(expense.IsPaid.ToString()) ? expense.IsPaid : exitExpense.IsPaid;
                exitExpense.InvoiceDate = !string.IsNullOrEmpty(expense.InvoiceDate.ToString()) ? expense.InvoiceDate : exitExpense.InvoiceDate;
                exitExpense.IsDeleted = !string.IsNullOrEmpty(expense.IsDeleted.ToString()) ? expense.IsDeleted : exitExpense.IsDeleted;
                exitExpense.FlatId = !string.IsNullOrEmpty(expense.FlatId.ToString()) ? expense.FlatId : exitExpense.FlatId;
                exitExpense.ExpenseTypeId = !string.IsNullOrEmpty(expense.ExpenseTypeId.ToString()) ? expense.ExpenseTypeId : exitExpense.ExpenseTypeId;

                repository.Update(exitExpense);
                unitOfWork.Commit();
            }
        }

        public async Task<List<ExpenseDto>> GetAllExpenseByRelations()
        {
            var expense = await expenseRepository.GetAllExpenseByRelationsAsync();
            var expenseDto = expense.Select(e => new ExpenseDto()
            {
                Id = e.Id,              
                Price = e.Price,                
                FlatId = e.Flat.Id,
                ExpenseTypeId = e.ExpenseType.Id,
                FlatNo = e.Flat.FlatNo,
                IsPaid = e.IsPaid,
                InvoiceDate = e.InvoiceDate,
                ExpenseTypeName = e.ExpenseType.ExpenseTypeName,
                
            }).ToList();

            return expenseDto;
        }

    }
}
