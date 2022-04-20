using ApartmanYonetimOtomasyonu.Business.DTOs;
using ApartmanYonetimOtomasyonu.Domain.Entities;
using FluentValidation;

namespace ApartmanYonetimOtomasyonu.Web.Models.FluentValidations
{
    public class UserValidation : AbstractValidator<UserCreateDto>
    {
        public UserValidation()
        {
            RuleFor(x => x.TCNo).NotEmpty().WithMessage("TC Kimlik alanı boş geçilemez.");
            RuleFor(x => x.TCNo).MinimumLength(10).MaximumLength(11).WithMessage("TC Kimlik Numaranızı tekrar kontrol ediniz.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez.");
            RuleFor(x => x.Email).MaximumLength(80).WithMessage("Email Uzunluğu 80 karakterden fazla olamaz.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email adresiniz geçerli değil.");

            RuleFor(x => x.CarLicensePlate).MaximumLength(50).WithMessage("Email Uzunluğu 50 karakterden fazla olamaz.");

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad alanı boş geçilemez.");
            RuleFor(x => x.FirstName).MaximumLength(50).WithMessage("Ad Uzunluğu 50 karakterden fazla olamaz.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyad alanı boş geçilemez.");
            RuleFor(x => x.LastName).MaximumLength(50).WithMessage("Soyad Uzunluğu 50 karakterden fazla olamaz.");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon Numarası alanı boş geçilemez.");
            RuleFor(x => x.PhoneNumber).Matches(@"^[0-9]*$").WithMessage("Telefon alanı sadece rakam içerebilir.");
            RuleFor(x => x.PhoneNumber).MaximumLength(11).WithMessage("Telefon Numarası alanı 11 karakterden fazla olamaz.");


        }
    }
}
