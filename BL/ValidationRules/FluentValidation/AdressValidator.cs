using EL.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ValidationRules.FluentValidation
{
   public class AdressValidator : AbstractValidator<Adress>
    {
        public AdressValidator()
        {
            RuleFor(x => x.Adres).NotNull().WithMessage("Id boş olamaz.");
            RuleFor(x => x.AdressName).NotNull().WithMessage("Adres adı boş olamaz.");
            RuleFor(x => x.City).NotNull().WithMessage("Şehir boş olamaz.");
            RuleFor(x => x.Country).NotNull().WithMessage("Ülke boş olamaz.");
            RuleFor(x => x.ZipCode).NotNull().WithMessage("Posta Kodu boş olamaz.");
        }
    }
}
