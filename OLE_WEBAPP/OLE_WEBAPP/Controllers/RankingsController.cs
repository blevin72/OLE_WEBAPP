using System;
using Microsoft.AspNetCore.Mvc;

namespace OLE_WEBAPP.Controllers
{
    public class RankingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SelectServer()
        {
            return View();
        }

        public IActionResult Top100All()
        {
            return View();
        }

        public IActionResult Top25Specific()
        {
            return View();
        }
    }

}

