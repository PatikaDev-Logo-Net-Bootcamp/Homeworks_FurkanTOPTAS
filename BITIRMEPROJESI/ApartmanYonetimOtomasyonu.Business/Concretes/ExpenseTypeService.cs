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

        public ExpenseTypeService(IRepository<ExpenseType> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Add(ExpenseType expenseType)
        {
            repository.Add(expenseType);
            unitOfWork.Commit();
        }

        public void Delete(ExpenseType expenseType)
        {
            var exitExpenseType = repository.Get().FirstOrDefault(x => x.Id == expenseType.Id);
            if (exitExpenseType != null)
            {
                exitExpenseType.IsDeleted = true;
                repository.Update(exitExpenseType);
                unitOfWork.Commit();
            }
        }

        public List<ExpenseType> GetAll()
        {
            return repository.Get().ToList();
        }

        public ExpenseType GetById(int Id)
        {
            return repository.Get().FirstOrDefault(x => x.Id == Id);
        }

        public void Update(ExpenseType expenseType)
        {
            var exitExpenseType = repository.Get().FirstOrDefault(x => x.Id == expenseType.Id);
            if (exitExpenseType != null)
            {
                exitExpenseType.ExpenseTypeName = !string.IsNullOrEmpty(expenseType.ExpenseTypeName) ? expenseType.ExpenseTypeName.ToUpper() : exitExpenseType.ExpenseTypeName;
                
                repository.Update(exitExpenseType);
                unitOfWork.Commit();
            }
        }
    }
   
}
