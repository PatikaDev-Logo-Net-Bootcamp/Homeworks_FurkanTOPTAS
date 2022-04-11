using ApartmanYonetimOtomasyonu.Business.Abstract;
using ApartmanYonetimOtomasyonu.DataAccess.EntityFramework.Repository.Abstracts;
using ApartmanYonetimOtomasyonu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Business.Concretes
{
    public class ExpenseTypeService : IExpenseTypeService
    {
        private readonly IRepository<ExpenseType> repository;
        private readonly IUnitOfWork unitOfWork;

        public void Add(ExpenseType expenseType)
        {
            throw new NotImplementedException();
        }

        public void Delete(ExpenseType expenseType)
        {
            throw new NotImplementedException();
        }

        public List<ExpenseType> GetAll()
        {
            throw new NotImplementedException();
        }

        public ExpenseType GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(ExpenseType expenseType)
        {
            throw new NotImplementedException();
        }
    }
   
}
