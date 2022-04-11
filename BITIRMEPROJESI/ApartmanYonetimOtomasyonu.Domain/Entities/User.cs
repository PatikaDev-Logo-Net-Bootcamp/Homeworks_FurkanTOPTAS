using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCNo { get; set; }
        public string CarLicensePlate { get; set; }
        public List<Flat> Flats { get; set; }
        public string TypeOfUser { get; set; } //Kullanıcı Tipi 1- Sahibi 2- Kiracı
    }
}
