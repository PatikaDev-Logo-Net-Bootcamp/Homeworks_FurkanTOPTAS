using ApartmanYonetimOtomasyonu.Business.Abstract;
using ApartmanYonetimOtomasyonu.DataAccess.EntityFramework.Repository.Abstracts;
using ApartmanYonetimOtomasyonu.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ApartmanYonetimOtomasyonu.Business.Concretes
{
    public class BuildingService : IBuildingService
    {
        private readonly IRepository<Building> repository;
        private readonly IUnitOfWork unitOfWork;

        public BuildingService(IRepository<Building> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public void Add(Building building)
        {
            repository.Add(building);
            unitOfWork.Commit();
        }

        public void Delete(Building building) // Bina sileceğiz :)
        {
            // 30 yıl sonra kentsel dönüşüme gidilecek olduğu için silme işlemi yapılacak :D
            var exitBuilding = repository.Get().FirstOrDefault(x => x.Id == building.Id);
            if (exitBuilding != null)
            {
                exitBuilding.IsDeleted = true;
                repository.Update(exitBuilding);
                unitOfWork.Commit();
            }
        }

        public List<Building> GetAll()
        {
            return repository.Get().ToList();
        }
        public Building GetById(int id)
        {
            return repository.Get().FirstOrDefault(x => x.Id == id);
        }

        public void Update(Building building)
        {
            var exitBuilding = repository.Get().FirstOrDefault(x => x.Id == building.Id);
            if (exitBuilding != null)
            {
                exitBuilding.BuildingName = !string.IsNullOrEmpty(building.BuildingName) ? building.BuildingName.ToUpper() : exitBuilding.BuildingName;
                exitBuilding.TotalFlat = !string.IsNullOrEmpty(building.TotalFlat.ToString()) ? building.TotalFlat : exitBuilding.TotalFlat;
                repository.Update(exitBuilding);
                unitOfWork.Commit();
            }            
        }
    }
}
