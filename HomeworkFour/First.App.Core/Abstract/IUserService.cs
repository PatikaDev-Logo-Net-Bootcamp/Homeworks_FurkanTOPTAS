using First.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace First.App.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAllUser();
        void AddUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);

    }
}
