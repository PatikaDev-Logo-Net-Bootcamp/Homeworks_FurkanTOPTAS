using ApartmanYonetimOtomasyonu.Business.DTOs;
using ApartmanYonetimOtomasyonu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Business.Abstract
{
    public interface IExpenseService
    {
        List<Expense> GetAll();
        Expense GetById(int Id);
        void Add(Expense expense);
        void Update(Expense expense);
        void Delete(Expense expense);

        Task<List<ExpenseDto>> GetAllExpenseByRelations();        
        void AddAllFlatsExpense(ExpenseCreateDto expenseCreateDto);        
    }
}
