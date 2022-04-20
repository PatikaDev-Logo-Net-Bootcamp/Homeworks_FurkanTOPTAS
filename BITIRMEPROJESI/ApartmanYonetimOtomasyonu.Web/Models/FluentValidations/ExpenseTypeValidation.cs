using ApartmanYonetimOtomasyonu.Domain.Entities;
using FluentValidation;

namespace ApartmanYonetimOtomasyonu.Web.Models.FluentValidations
{
    public class ExpenseTypeValidation : AbstractValidator<ExpenseType>
    {
        public ExpenseTypeValidation()
        {
            RuleFor(x => x.ExpenseTypeName).NotEmpty().WithMessage("Gider türü adı boş olamaz.");
            RuleFor(x => x.ExpenseTypeName).MaximumLength(50).WithMessage("Maksimum 50 Karakter Girilebilir.");
        }
    }
}
