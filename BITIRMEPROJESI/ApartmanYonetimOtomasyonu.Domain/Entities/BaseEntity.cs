using System;
using System.ComponentModel.DataAnnotations;

namespace ApartmanYonetimOtomasyonu.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        
    }
}
