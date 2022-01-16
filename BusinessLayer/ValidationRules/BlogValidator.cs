using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Başlığı Boş Olamaz");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("İçerik Boş Olamaz");
            RuleFor(x => x.BlogContent).NotNull().WithMessage("İçerik Boş Olamaz");
            RuleFor(x => x.BlogTitle).NotNull().WithMessage("Blog Başlığı Boş Olamaz");
            RuleFor(x => x.BlogTitle).MaximumLength(50).WithMessage("Blog Başlığı 50 Karakterden Fazla Olamaz");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Blog Başlığı 5 Karakterden Az Olamaz");
            RuleFor(x => x.BlogContent).MinimumLength(100).WithMessage("Blog İçeriği 100 Karakterden Az Olamaz");
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Lütfen Kategoriyi Seçin");
            RuleFor(x => x.CategoryID).NotNull().WithMessage("Lütfen Kategoriyi Seçin");
            

        }
    }
}
