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
    public class ExpenseService : IExpenseService
    {
        private readonly IRepository<Expense> repository;
        private readonly IUnitOfWork unitOfWork;

        public ExpenseService(IRepository<Expense> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Add(Expense expense)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expense expense)
        {
            throw new NotImplementedException();
        }

        public List<Expense> GetAll()
        {
            throw new NotImplementedException();
        }

        public Expense GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Expense expense)
        {
            throw new NotImplementedException();
        }
    }
}
