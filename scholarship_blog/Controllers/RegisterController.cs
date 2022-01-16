using BusinessLayer.Concrate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scholarship_blog.Controllers
{
    public class RegisterController : Controller
    {
        // yazar kayıt işlemleri
        WriterManager wm = new WriterManager(new EfWriterRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        // Yazar Kaydı
        [HttpPost]
        public IActionResult Index(Writer model)
        {

            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(model);


            if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View();
            }

            else
            {

                model.WriterStatus = true;
                wm.TAdd(model);
                ViewBag.notification = "notnull";
                return View();

            }
        }

    }
}
