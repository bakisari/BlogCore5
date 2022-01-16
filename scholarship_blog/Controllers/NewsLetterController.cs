using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scholarship_blog.Controllers
{
    public class NewsLetterController : Controller
    {
        NewslatterManager nw = new NewslatterManager(new EfNewsLetterRepository());

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();

        }
        [HttpPost]
        public IActionResult SubscribeMail(NewsLater newsLater)
        {
            newsLater.Status = true;
            nw.AddNewsLetter(newsLater);
            return RedirectToAction("Index", "Blog", TempData["blogid"]);
        }
    }
}
