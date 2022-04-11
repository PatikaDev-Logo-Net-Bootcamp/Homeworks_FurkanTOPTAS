using ApartmanYonetimOtomasyonu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Business.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAll();
        Message GetById(int Id);
        void Add(Message message);
        void Update(Message message);
        void Delete(Message message);
    }
}
