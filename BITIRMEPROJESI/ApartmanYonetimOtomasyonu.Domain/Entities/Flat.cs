using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Domain.Entities
{
    public class Flat : BaseEntity
    {
        public int FlatNo { get; set; } //Apartman Numarası
        public bool IsEmpty { get; set; } //Dolu mu Boş mu ?
        public string Block { get; set; } //blok tipi
        public int Floor { get; set; } //Bulunduğu Kat 
        public int RoomSize { get; set; } //Oda Sayısı
        public int SaloonSize { get; set; } //Salon Sayısı
        public string TypeOfFlat {
            get { return RoomSize.ToString() + "+" + SaloonSize.ToString(); } // Oda ve Salon Sayısı
        }
        public string UserId { get; set; }
        public User User { get; set; } //Kullanıcı Bilgileri
        public string TypeOfUser { get; set; } //Kullanıcı Tipi 1- Sahibi 2- Kiracı
        public int BuildingId { get; set; }
        public Building Building { get; set; } // Bina Bilgileri

        public List<Expense> Expenses { get; set; } // Giderler

    }
}
