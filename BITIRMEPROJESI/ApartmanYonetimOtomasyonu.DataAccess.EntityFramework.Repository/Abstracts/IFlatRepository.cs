using ApartmanYonetimOtomasyonu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.DataAccess.EntityFramework.Repository.Abstracts
{
    public interface IFlatRepository : IRepository<Flat>
    {
        Task<List<Flat>> GetAllFlatsByRelationsAsync();
    }
}
