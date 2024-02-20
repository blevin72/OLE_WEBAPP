using System;
using Microsoft.AspNetCore.Mvc;

namespace OLE_WEBAPP.Controllers
{
    public class MediaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Trailers()
        {
            return View();
        }

        public IActionResult MomentOfTheMonth()
        {
            return View();
        }
    }
}

