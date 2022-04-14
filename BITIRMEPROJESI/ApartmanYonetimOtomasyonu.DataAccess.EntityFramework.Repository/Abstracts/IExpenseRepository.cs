using ApartmanYonetimOtomasyonu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.DataAccess.EntityFramework.Repository.Abstracts
{
    public interface IExpenseRepository
    {
        Task<List<Expense>> GetAllExpenseByRelationsAsync();
    }
}
