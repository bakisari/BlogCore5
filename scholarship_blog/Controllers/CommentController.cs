using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scholarship_blog.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult PartialAddComment(Comment p)
        {
            var blogid = TempData["blogid"];
            p.BlogID = Convert.ToInt32(blogid);
            p.CommentStatus = true;
            p.CreateDate = DateTime.Parse( DateTime.Now.ToShortDateString());
            cm.TAdd(p);
            return RedirectToAction("Index", "Blog");
        }
       
    }
}
