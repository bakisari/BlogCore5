using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scholarship_blog.ViewComponents
{
    public class CommentList :ViewComponent
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke(int id)
        {
           
            var values = cm.AllListBlogID(id);
            return View(values);
        }
    }
}
