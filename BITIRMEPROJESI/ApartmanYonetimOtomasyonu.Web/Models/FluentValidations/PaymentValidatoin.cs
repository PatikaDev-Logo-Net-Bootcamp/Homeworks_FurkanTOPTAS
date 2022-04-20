using ApartmanYonetimOtomasyonu.Business.DTOs;
using FluentValidation;

namespace ApartmanYonetimOtomasyonu.Web.Models.FluentValidations
{
    public class PaymentValidatoin : AbstractValidator<PaymentCreateDto>
    {
        public PaymentValidatoin()
        {
            RuleFor(x => x.ValidMonth).NotEmpty().WithMessage("Ay alanı boş geçilemez.");
            RuleFor(x => x.ValidMonth).Must(x => x >= 1 && x <= 12).WithMessage("Ay alanı 1-12 arasında olmalıdır.");

            RuleFor(x => x.ValidYear).NotEmpty().WithMessage("Yıl alanı boş geçilemez.");
            RuleFor(x => x.ValidYear).Must(x => x >= 1 && x <= 9999).WithMessage("Yıl alanı 1-9999 arasında olmalıdır.");

            RuleFor(x => x.Owner).NotEmpty().WithMessage("Kart Sahibi alanı boş geçilemez.");
            RuleFor(x => x.Owner).MaximumLength(50).WithMessage("Kart Sahibi alanı Maksimum 50 karakter olmalıdır.");

            RuleFor(x => x.CardNumber).NotEmpty().WithMessage("Kart Numarası alanı boş geçilemez.");
            RuleFor(x => x.CardNumber).MaximumLength(16).WithMessage("Kart Numarası alanı Maksimum 16 karakter olmalıdır.");

            RuleFor(x => x.Cvv).NotEmpty().WithMessage("CVV alanı boş geçilemez.");            
            RuleFor(x => x.Cvv).Must(x => x >= 1 && x <= 999).WithMessage("CVV alanı Maksimum 3 karakter olmalıdır.");

            RuleFor(x => x.ExpenseId).NotEmpty().WithMessage("Gider alanı boş geçilemez.");
            
            RuleFor(x => x.FlatId).NotEmpty().WithMessage("Daire alanı boş geçilemez.");  
            

        }
    }
}
