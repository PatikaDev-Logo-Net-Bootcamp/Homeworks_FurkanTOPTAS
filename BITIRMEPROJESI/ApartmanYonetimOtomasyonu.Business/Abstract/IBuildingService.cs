using ApartmanYonetimOtomasyonu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Business.Abstract
{
    public interface IBuildingService
    {
        List<Building> GetAll();
        Building GetById(int Id);
        void Add(Building building);
        void Update(Building building);
        void Delete(Building building);
    }
}
