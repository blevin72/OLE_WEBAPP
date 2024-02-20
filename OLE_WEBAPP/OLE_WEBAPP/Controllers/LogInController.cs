using System;
using Microsoft.AspNetCore.Mvc;

namespace OLE_WEBAPP.Controllers
{
    public class LogInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }

}

