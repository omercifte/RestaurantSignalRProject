using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SignalRDtoLayer.BookingDto;

namespace SignalRBusinessLayer.ValidationRules.BookingValidations
{
    public class CreateBookingValidation:AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim  Boş Geçilemez");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon Boş Geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Email Boş Geçilemez").EmailAddress().WithMessage("Geçerli bir mail adresi giriniz.");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi Alanı Boş Geçilemez");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Lütfen Tarih Seçiniz");

            

        }
    }
}
