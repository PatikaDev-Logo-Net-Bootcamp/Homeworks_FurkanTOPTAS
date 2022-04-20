using ApartmanYonetimOtomasyonu.Business.DTOs;
using FluentValidation;

namespace ApartmanYonetimOtomasyonu.Web.Models.FluentValidations
{
    public class FlatValidation : AbstractValidator<FlatCreateDto>
    {
        public FlatValidation()
        {
            RuleFor(x => x.FlatNo).NotEmpty().WithMessage("Daire Numarası alanı boş geçilemez.");
            RuleFor(x => x.FlatNo).Must(x=> x>0 && x<=500).WithMessage("Daire Numarası alanı 1-500 aralığında olmalıdır.");

            RuleFor(x => x.Floor).NotEmpty().WithMessage("Daire Kat Sayısı alanı boş geçilemez.");
            RuleFor(x => x.Floor).Must(x => x > 0 && x <= 50).WithMessage("Daire Kat Sayısı alanı 1-50 aralığında olmalıdır.");

            RuleFor(x => x.RoomSize).NotEmpty().WithMessage("Oda Sayısı alanı boş geçilemez.");
            RuleFor(x => x.RoomSize).Must(x => x > 0 && x <= 15).WithMessage("Oda Sayısı alanı 1-15 aralığında olmalıdır.");

            RuleFor(x => x.SaloonSize).NotEmpty().WithMessage("Salon Sayısı alanı boş geçilemez.");
            RuleFor(x => x.SaloonSize).Must(x => x > 0 && x <= 15).WithMessage("Salon Sayısı alanı 1-15 aralığında olmalıdır.");

            RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı alanı boş geçilemez.");
            RuleFor(x => x.BuildingId).NotEmpty().WithMessage("Daire alanı boş geçilemez.");
                        
        }
    }
}
