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
    public class FlatConfiguration : IEntityTypeConfiguration<Flat>
    {
        public void Configure(EntityTypeBuilder<Flat> builder)
        {

            builder.HasOne<User>(b => b.User)
                .WithMany(u => u.Flats)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Building>(b => b.Building)
                .WithMany(u => u.Flats)
                .HasForeignKey(b => b.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
