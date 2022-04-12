using ApartmanYonetimOtomasyonu.Business.Abstract;
using ApartmanYonetimOtomasyonu.Business.DTOs;
using ApartmanYonetimOtomasyonu.DataAccess.EntityFramework.Repository.Abstracts;
using ApartmanYonetimOtomasyonu.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Business.Concretes
{
    public class FlatService : IFlatService
    {
        private readonly IRepository<Flat> repository;
        private readonly IFlatRepository flatRepository;
        private readonly IUnitOfWork unitOfWork;

        public FlatService(IRepository<Flat> repository, IFlatRepository flatRepository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.flatRepository = flatRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Add(Flat flat) // Daire Ekleme
        {
            repository.Add(flat);
            unitOfWork.Commit();
        }

        public void Delete(Flat flat) // Daire Silme
        {
            var exitFlat = repository.Get().FirstOrDefault(x => x.Id == flat.Id);
            if (exitFlat != null)
            {
                exitFlat.IsDeleted = true;
                repository.Update(exitFlat);
                unitOfWork.Commit();
            }
        }

        public List<Flat> GetAll() // Daire Listeleme
        {
            return repository.Get().ToList();
        }

        public Flat GetById(int Id) // Daire Lisreleme ID ye göre
        {
            return repository.Get().FirstOrDefault(x => x.Id == Id);
        }

        public void Update(Flat flat) // Daire Güncelleme
        {
            var exitFlat = repository.Get().FirstOrDefault(x => x.Id == flat.Id);
            if (exitFlat != null)
            {
                exitFlat.FlatNo = !string.IsNullOrEmpty(flat.FlatNo.ToString()) ? flat.FlatNo : exitFlat.FlatNo;
                exitFlat.Floor = !string.IsNullOrEmpty(flat.Floor.ToString()) ? flat.Floor : exitFlat.Floor;
                exitFlat.RoomSize = !string.IsNullOrEmpty(flat.RoomSize.ToString()) ? flat.RoomSize : exitFlat.RoomSize;
                exitFlat.SaloonSize = !string.IsNullOrEmpty(flat.SaloonSize.ToString()) ? flat.SaloonSize : exitFlat.SaloonSize;

                repository.Update(exitFlat);
                unitOfWork.Commit();
            }
        }
        
        public async Task<List<FlatDto>> GetAllFlatsByRelations()
        {
            var flats = await flatRepository.GetAllFlatsByRelationsAsync();
            var flatDto = flats.Select(f => new FlatDto()
            {
                Id = f.Id,
                FlatNo = f.FlatNo,
                Floor = f.Floor,
                IsEmpty = f.IsEmpty,
                RoomSize = f.RoomSize,
                SaloonSize = f.SaloonSize,
                BuildingName = f.Building.BuildingName,
                FirstName = f.User.FirstName,
            }).ToList();
            
            return flatDto;
        }


    }
}
