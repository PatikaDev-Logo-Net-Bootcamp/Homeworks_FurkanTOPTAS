using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Domain.Entities
{
    public class Building : BaseEntity
    { 
        public string BuildingName { get; set; }
        public int TotalFlat { get; set; }
        public List<Flat> Flats { get; set; }
    }
}
