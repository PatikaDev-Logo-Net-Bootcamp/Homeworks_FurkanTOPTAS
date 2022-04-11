using ApartmanYonetimOtomasyonu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.EntityFramework.Configurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasOne<Flat>(b => b.Flat)
                .WithMany(u => u.Expenses)
                .HasForeignKey(b => b.FlatId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<ExpenseType>(b => b.ExpenseType)
                .WithMany(u => u.Expenses)
                .HasForeignKey(b => b.ExpenseTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
