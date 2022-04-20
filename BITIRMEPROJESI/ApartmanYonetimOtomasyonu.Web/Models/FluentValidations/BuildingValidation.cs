using ApartmanYonetimOtomasyonu.Domain.Entities;
using FluentValidation;

namespace ApartmanYonetimOtomasyonu.Web.Models.FluentValidations
{
    public class BuildingValidation : AbstractValidator<Building>
    {
        public BuildingValidation()
        {
            RuleFor(x => x.BuildingName).NotEmpty().WithMessage("Apartman Adı alanı boş geçilemez.");
            RuleFor(x => x.BuildingName).Length(1).WithMessage("Apartman Adı alanı maksimum 1 karakter uzunluğunda olmalıdır.");
            RuleFor(x => x.TotalFloor).NotEmpty().WithMessage("Toplam Kat Sayısı alanı boş geçilemez.");
            RuleFor(x => x.TotalFloor).Must(x => x >= 1 && x <= 50).WithMessage("Toplam Kat Sayısı alanı 1-50 arasında olmalıdır.");
            RuleFor(x => x.TotalFlat).NotEmpty().WithMessage("Toplam Daire Sayısı alanı boş geçilemez.");
            RuleFor(x => x.TotalFlat).Must(x => x >= 1 && x <= 500).WithMessage("Toplam Daire Sayısı alanı 1-500 arasında olmalıdır.");

        }
    }
}
