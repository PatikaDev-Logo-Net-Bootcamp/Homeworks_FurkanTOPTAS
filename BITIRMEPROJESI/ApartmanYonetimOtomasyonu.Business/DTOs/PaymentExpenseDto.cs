using ApartmanYonetimOtomasyonu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Business.DTOs
{
    public class PaymentExpenseDto
    {
        public int Id { get; set; }
        public bool IsPaid { get; set; }
        public decimal Price { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string UserName { get; set; }
        public int FlatId { get; set; }
        public byte FlatNumber { get; set; }
        public string ExpenseTypeName { get; set; }
        public ExpenseType ExpenseType { get; set; }
    }
}
