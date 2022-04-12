using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Business.DTOs
{
    public class FlatDto
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
        public string FirstName { get; set; }
        public string BuildingName { get; set; }
    }
}
