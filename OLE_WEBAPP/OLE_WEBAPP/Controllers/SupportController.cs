using System;
using Microsoft.AspNetCore.Mvc;

namespace OLE_WEBAPP.Controllers
{
    public class SupportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Email()
        {
            return View();
        }

        public IActionResult FAQs()
        {
            return View();
        }
    }
}