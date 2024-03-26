using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OLE_WEBAPP.Data;
using OLE_WEBAPP.Models;

namespace OLE_WEBAPP.Controllers
{
    public class MainController : Controller
    {
        private readonly AppDbContext _context;

        public MainController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ExistingPost()
        {
            var existingPosts = _context.CommunicationRecords.ToList();
            return View(existingPosts);
        }

        public IActionResult NewPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewPost(CommunicationRecord record)
        {
            if (ModelState.IsValid)
            {
                record.TimeSent = DateTime.Now; // Set the current time
                _context.CommunicationRecords.Add(record);
                _context.SaveChanges();
                return RedirectToAction("ExistingPost");
            }
            return View(record);
        }
    }
}