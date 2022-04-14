using ApartmanYonetimOtomasyonu.DataAccess.EntityFramework.Repository.Abstracts;
using ApartmanYonetimOtomasyonu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.DataAccess.EntityFramework.Repository.Concretes
{
    public class ExpenseRepository : Repository<Expense> , IExpenseRepository
    {
        public ExpenseRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<List<Expense>> GetAllExpenseByRelationsAsync()
        {

            return await unitOfWork.Context.Expenses
                .Include(x => x.ExpenseType)                
                .Include(x => x.Flat)
                .ThenInclude(x => x.User)     
                .Where(x => x.IsDeleted == false)                
                .ToListAsync();
        }
    }
}
