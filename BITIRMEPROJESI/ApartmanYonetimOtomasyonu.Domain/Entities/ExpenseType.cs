using System.Collections.Generic;

namespace ApartmanYonetimOtomasyonu.Domain.Entities
{
    public class ExpenseType : BaseEntity
    {
        public string ExpenseTypeName { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}