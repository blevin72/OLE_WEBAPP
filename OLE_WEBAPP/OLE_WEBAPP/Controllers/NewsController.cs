using System;
using Microsoft.AspNetCore.Mvc;

namespace OLE_WEBAPP.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Seasons()
        {
            return View();
        }

        public IActionResult SpecialEvents()
        {
            return View();
        }

        public IActionResult PatchUpdates()
        {
            return View();
        }

        public IActionResult Deals()
        {
            return View();
        }
    }
}

