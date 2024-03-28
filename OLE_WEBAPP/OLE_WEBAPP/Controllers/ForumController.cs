using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OLE_WEBAPP.Data;
using OLE_WEBAPP.Interfaces;
using OLE_WEBAPP.Models;
using OLE_WEBAPP.Services;

namespace OLE_WEBAPP.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForumServices _forumServices;

        public ForumController(IForumServices forumServices)
        {
            _forumServices = forumServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewPost()
        {
            return View();
        }

        public IActionResult ExistingPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetExistingPost()
        {
            var existingPosts = _forumServices.GetExistingPosts();
            return View(existingPosts);
        }

        [HttpPost]
        public IActionResult NewPost(CommunicationRecord record)
        {
            if (ModelState.IsValid)
            {
                _forumServices.CreatePost(record);
                return RedirectToAction("ExistingPost");
            }
            return View(record);
        }
    }
}