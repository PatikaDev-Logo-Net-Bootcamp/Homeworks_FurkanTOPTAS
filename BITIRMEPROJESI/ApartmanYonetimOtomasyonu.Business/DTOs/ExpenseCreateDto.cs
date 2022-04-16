using ApartmanYonetimOtomasyonu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Business.DTOs
{
    public class ExpenseCreateDto
    {
        public int Id { get; set; }
        public bool IsPaid { get; set; }
        public decimal Price { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int FlatId { get; set; }
        public int FlatNo { get; set; }
        public int ExpenseTypeId { get; set; }
        public int BuildingId { get; set; }

        public IEnumerable<ExpenseType> ExpenseType { get; set; }
        public IEnumerable<Flat> Flat { get; set; }
        public IEnumerable<Building> Building { get; set; }
    }
}
