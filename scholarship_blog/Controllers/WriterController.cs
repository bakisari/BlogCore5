using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scholarship_blog.Controllers
{
    public class WriterController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            return View();
        }
        // Yazarın Kendi Blogları 
        public IActionResult WriterBlogList()
        {
          
            int id = 4;
            var values = bm.CategoryByWriter(id);
            return View(values);
        }
    }
}
