using ApartmanYonetimOtomasyonu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Business.DTOs
{
    public class FlatCreateDto
    {
        public int Id { get; set; }
        public int FlatNo { get; set; } //Apartman Numarası
        public bool IsEmpty { get; set; } //Dolu mu Boş mu ?
        public int Floor { get; set; } //Bulunduğu Kat 
        public int RoomSize { get; set; } //Oda Sayısı
        public int SaloonSize { get; set; } //Salon Sayısı
        public string TypeOfFlat
        {
            get { return RoomSize.ToString() + "+" + SaloonSize.ToString(); } // Oda ve Salon Sayısı
        }
        public string UserId { get; set; }
     
        public int BuildingId { get; set; }

        public IEnumerable<Building> Buildings { get; set; } 
        public IEnumerable<User> Users { get; set; }

    }
}
