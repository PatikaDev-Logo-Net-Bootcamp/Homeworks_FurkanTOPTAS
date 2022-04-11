using ApartmanYonetimOtomasyonu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Business.Abstract
{
    public interface IExpenseTypeService
    {
        List<ExpenseType> GetAll();
        ExpenseType GetById(int Id);
        void Add(ExpenseType expenseType);
        void Update(ExpenseType expenseType);
        void Delete(ExpenseType expenseType);
    }
}
