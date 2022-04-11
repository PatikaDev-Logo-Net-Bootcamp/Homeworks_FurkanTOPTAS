using ApartmanYonetimOtomasyonu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Business.Abstract
{
    public interface IFlatService
    {
        List<Flat> GetAll();
        Flat GetById(int Id);
        void Add(Flat flat);
        void Update(Flat flat);
        void Delete(Flat flat);
    }
}
