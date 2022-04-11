using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Domain.Entities
{
    public class Expense: BaseEntity
    {
        public bool IsPaid { get; set; }
        public decimal Price { get; set; }
        public DateTime InvoiceDate { get; set; }

        public int FlatId { get; set; }
        public Flat Flat { get; set; }

        public int ExpenseTypeId { get; set; }
        public ExpenseType ExpenseType { get; set; }
    }
}
