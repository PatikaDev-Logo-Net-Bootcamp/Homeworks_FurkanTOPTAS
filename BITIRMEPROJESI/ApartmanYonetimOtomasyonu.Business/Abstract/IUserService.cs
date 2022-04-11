using ApartmanYonetimOtomasyonu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int Id);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
