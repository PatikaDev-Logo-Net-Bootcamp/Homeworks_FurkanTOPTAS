using ApartmanYonetimOtomasyonu.Domain.Entities;
using FluentValidation;

namespace ApartmanYonetimOtomasyonu.Web.Models.FluentValidations
{
    public class MessageValidation : AbstractValidator<Message>
    {
        public MessageValidation()
        {
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajınızı giriniz.");
            RuleFor(x => x.MessageContent).MaximumLength(500).WithMessage("En fazla 500 karakter girilebilir.");

        }

    }
}
