using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("İsim Boş Geçilemez");
            RuleFor(x => x.WriterName).NotNull().WithMessage("İsim Boş Geçilemez");
            RuleFor(x => x.WriterName).MaximumLength(30).WithMessage("İsim 30 Karakterden Uzun Olamaz");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("İsim 3 Karakterden Az Olamaz");
            RuleFor(x => x.WriterMail).MinimumLength(3).WithMessage("E-Posta 8 Karakterden Az Olamaz");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Lütfen Geçerli Bir Mail Adresi Giriniz");
            RuleFor(x => x.WriterMail).NotNull().WithMessage("E Posta Adresi Boş Olamaz");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("E Posta Adresi Boş Olamaz");
            RuleFor(x => x.WriterPassword).NotNull().WithMessage("Şifre Boş Geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre Boş Geçilemez");
            RuleFor(x => x.WriterPassword).MinimumLength(6).WithMessage("Şifre 6 Karakterden Az Olamaz");
            RuleFor(x => x.WriterPassword).MaximumLength(11).WithMessage("Şifre 11 Karakterden Fazla Olamaz");


        }
    }
}
