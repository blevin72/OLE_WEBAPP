using System;
using Microsoft.AspNetCore.Mvc;

namespace OLE_WEBAPP.Controllers
{
    public class ForumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ExistingPost()
        {
            return View();
        }

        public IActionResult NewPost()
        {
            return View();
        }
    }
}

