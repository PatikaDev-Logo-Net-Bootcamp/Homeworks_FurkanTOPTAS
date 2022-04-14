using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Business.DTOs
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public bool IsPaid { get; set; }
        public decimal Price { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int FlatId { get; set; }
        public int FlatNo { get; set; }
        public int ExpenseTypeId{ get; set; }
        public string ExpenseTypeName{ get; set; }
    }
}
