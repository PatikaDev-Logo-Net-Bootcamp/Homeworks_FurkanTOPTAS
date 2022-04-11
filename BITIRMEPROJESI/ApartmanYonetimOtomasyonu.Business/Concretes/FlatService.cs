using ApartmanYonetimOtomasyonu.Business.Abstract;
using ApartmanYonetimOtomasyonu.DataAccess.EntityFramework.Repository.Abstracts;
using ApartmanYonetimOtomasyonu.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ApartmanYonetimOtomasyonu.Business.Concretes
{
    public class FlatService : IFlatService
    {
        private readonly IRepository<Flat> repository;
        private readonly IUnitOfWork unitOfWork;

        public FlatService(IRepository<Flat> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
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
    }
}
