using BusinessLayer.Concrate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scholarship_blog.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
        // Blog Detay Sayfası
        public IActionResult BlogReadAll(int id)
        {
            TempData["blogid"] = id;
            var values = bm.TGetByID(id);
            ViewBag.id = id;
            return View(values);
        }
        // Blog Ekleme 
        [HttpGet]
        public IActionResult BlogAdd()
        {
            //Kategori listesi
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> CategoryValues = (from x in cm.AllList()
                                                   select new SelectListItem
                                                   {
                                                       Text=x.CategoryName,
                                                       Value=x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.categoryvalues = CategoryValues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {

            //Kategori listesi
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> CategoryValues = (from x in cm.AllList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.categoryvalues = CategoryValues;

            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(blog);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                if (blog.CategoryID<1)
                {
                    string message = "Kategori Seçin";
                    ViewBag.message = message;
                }
                return View();
            }

            else
            {
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.BlogStatus = false;
                blog.WriterID = 4;
                blog.BlogImage = "/web//images/1.jpg";
                blog.Deleted = false;
                bm.TAdd(blog);
                TempData["values"]=true;
                return RedirectToAction("WriterBlogList", "Writer");
            }   
          
        }
        // Blog Sil
        public IActionResult BlogDeleted(int id)
        {
            var blogvalue = bm.TGetByID(id);
            blogvalue.Deleted = true;
            bm.TUpdate(blogvalue);
            return RedirectToAction("WriterBlogList", "Writer");
        }
        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> CategoryValues = (from x in cm.AllList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.categoryvalues = CategoryValues;
            var values= bm.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateBlog(Blog blog)
        {
            
            bm.TUpdate(blog);
            return RedirectToAction("WriterBlogList", "Writer");
        }
    }
}
