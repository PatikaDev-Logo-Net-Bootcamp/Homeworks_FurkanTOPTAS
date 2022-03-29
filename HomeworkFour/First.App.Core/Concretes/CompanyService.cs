using First.App.Business.Abstract;
using First.App.Business.DTOs;
using First.App.DataAccess.EntityFramework.Repository.Abstracts;
using First.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace First.App.Business.Concretes
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> repository;
        private readonly IUnitOfWork unitOfWork;
        public CompanyService(IRepository<Company> repository, IUnitOfWork unitOfWork)
        {
          this.repository = repository;
          this.unitOfWork = unitOfWork;
        }

        public void AddCompany(Company company)
        {
            repository.Add(company);
            unitOfWork.Commit();
        }

        public List<Company> GetAllCompany()
        {
            return repository.Get().ToList();
        }


        public void DeleteCompany(Company company)
        {
            var exitCompany = repository.Get().FirstOrDefault(x => x.Id == company.Id);
            if (exitCompany != null)
            {
                exitCompany.IsDeleted= true;
                repository.Update(exitCompany);
                unitOfWork.Commit();
            }
           
        }
        public void UpdateCompany(Company company)
        {
            var exitCompany = repository.Get().Where(x => x.Id == company.Id).SingleOrDefault(); 

            //Bu kısım baya kokuyor lütfen bu kısma önerilerinizi ekleyebilirsiniz.
            // Default değer olduğu zaman SQL e eklememesi kontrolü yapılıyor normalde
            // fakat sürem yetersiz olduğu için bu kısmı araştıramadım. 

            if (exitCompany != null)
            {
                exitCompany.Description = company.Description;
                exitCompany.Address = company.Address;
                exitCompany.City = company.City;
                exitCompany.LastUpdatedBy = company.LastUpdatedBy;
                exitCompany.Country= company.Country;
                exitCompany.IsDeleted = false;
                exitCompany.CreatedAt = company.CreatedAt;
                exitCompany.CreatedBy = company.CreatedBy;
                exitCompany.LastUpdatedAt = company.LastUpdatedAt;
                exitCompany.LastUpdatedBy = company.LastUpdatedBy;
                exitCompany.Location = company.Location;
                exitCompany.Phone = company.Phone;
                exitCompany.Name = company.Name;

                repository.Update(exitCompany);
                unitOfWork.Commit();
            }
        }

    }
}
