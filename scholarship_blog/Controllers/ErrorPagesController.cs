using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scholarship_blog.Controllers
{
    public class ErrorPagesController : Controller
    {
        public IActionResult Error1(int code)
        {
            return View();
        }
    }
}
