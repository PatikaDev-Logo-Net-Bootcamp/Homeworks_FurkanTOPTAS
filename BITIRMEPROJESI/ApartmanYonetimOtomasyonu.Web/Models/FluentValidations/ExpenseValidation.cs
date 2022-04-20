using ApartmanYonetimOtomasyonu.Business.DTOs;
using FluentValidation;

namespace ApartmanYonetimOtomasyonu.Web.Models.FluentValidations
{
    public class ExpenseValidation : AbstractValidator<ExpenseDto>
    {
        public ExpenseValidation()
        {
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat alanı boş geçilemez.");
            RuleFor(x => x.Price).Must(x=> x >=0 && x<=9999).WithMessage("Fiyat alanı 0-9999 aralıgında olmalıdır.");          
            
        }
    }
}
