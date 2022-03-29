using First.App.Business.Abstract;
using First.App.DataAccess.EntityFramework.Repository.Abstracts;
using First.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace First.App.Business.Concretes
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> repository;
        private readonly IUnitOfWork unitOfWork;
        public UserService(IRepository<User> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public void AddUser(User user)
        {
            repository.Add(user);
            unitOfWork.Commit();
        }

        public void DeleteUser(User user)
        {
            repository.Delete(user);
            unitOfWork.Commit();
        }

        public List<User> GetAllUser()
        {
            return repository.Get().ToList();
        }

        public void UpdateUser(User user)
        {

            repository.Update(user);
            unitOfWork.Commit();
        }
    }
}
