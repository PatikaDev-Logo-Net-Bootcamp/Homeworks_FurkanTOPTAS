using ApartmanYonetimOtomasyonu.DataAccess.EntityFramework.Repository.Abstracts;
using ApartmanYonetimOtomasyonu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.DataAccess.EntityFramework.Repository.Concretes
{
    public class FlatRepository : Repository<Flat> , IFlatRepository
    {
        public FlatRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<List<Flat>> GetAllFlatsByRelationsAsync()
        {
            return await unitOfWork.Context.Flats
               .Include(x => x.User)
               .Include(x => x.Building)
               .OrderBy(x => x.FlatNo)
               .ToListAsync();
        }
    }
}
