using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OLE_WEBAPP.Data;
using OLE_WEBAPP.Models;

namespace OLE_WEBAPP.Controllers
{
    public class FriendsListController : Controller
    {
        private readonly AppDbContext _context;

        // Constructor injection for AppDbContext
        public FriendsListController(AppDbContext context)
        {
            _context = context;
        }

        // Action method for displaying the list of friends
        public async Task<IActionResult> Index()
        {
            // Retrieve friends list from the database and include related account information
            var friendsList = await _context.FriendsList
                .Include(f => f.Account1)
                .Include(f => f.Account2)
                .ToListAsync();

            return View(friendsList);
        }

        // Action method for displaying details of a specific friendship
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FriendsList == null)
            {
                return NotFound();
            }

            var friendsList = await _context.FriendsList
                .Include(f => f.Account1)
                .Include(f => f.Account2)
                .FirstOrDefaultAsync(m => m.FriendshipId == id);

            if (friendsList == null)
            {
                return NotFound();
            }

            return View(friendsList);
        }

        // Action method for displaying the form to create a new friendship
        public IActionResult Create()
        {
            // Populate dropdown lists with account IDs
            ViewData["Account1Id"] = new SelectList(_context.Accounts, "Id", "Id");
            ViewData["Account2Id"] = new SelectList(_context.Accounts, "Id", "Id");
            return View();
        }

        // POST action method for handling the creation of a new friendship
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FriendshipId,Account1Id,Account2Id,FriendshipTimeStamp")] FriendsList friendsList)
        {
            if (ModelState.IsValid)
            {
                // Add the new friendship to the database
                _context.Add(friendsList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // If the model state is not valid, return to the create view with errors
            ViewData["Account1Id"] = new SelectList(_context.Accounts, "Id", "Id", friendsList.Account1Id);
            ViewData["Account2Id"] = new SelectList(_context.Accounts, "Id", "Id", friendsList.Account2Id);
            return View(friendsList);
        }

        // Action method for displaying the form to edit a friendship
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FriendsList == null)
            {
                return NotFound();
            }

            var friendsList = await _context.FriendsList.FindAsync(id);
            if (friendsList == null)
            {
                return NotFound();
            }
            // Populate dropdown lists with account IDs
            ViewData["Account1Id"] = new SelectList(_context.Accounts, "Id", "Id", friendsList.Account1Id);
            ViewData["Account2Id"] = new SelectList(_context.Accounts, "Id", "Id", friendsList.Account2Id);
            return View(friendsList);
        }

        // POST action method for handling the editing of a friendship
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FriendshipId,Account1Id,Account2Id,FriendshipTimeStamp")] FriendsList friendsList)
        {
            if (id != friendsList.FriendshipId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Update the friendship in the database
                    _context.Update(friendsList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FriendsListExists(friendsList.FriendshipId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Account1Id"] = new SelectList(_context.Accounts, "Id", "Id", friendsList.Account1Id);
            ViewData["Account2Id"] = new SelectList(_context.Accounts, "Id", "Id", friendsList.Account2Id);
            return View(friendsList);
        }

        // Action method for displaying the form to delete a friendship
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FriendsList == null)
            {
                return NotFound();
            }

            var friendsList = await _context.FriendsList
                .Include(f => f.Account1)
                .Include(f => f.Account2)
                .FirstOrDefaultAsync(m => m.FriendshipId == id);
            if (friendsList == null)
            {
                return NotFound();
            }

            return View(friendsList);
        }

        // POST action method for handling the deletion of a friendship
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FriendsList == null)
            {
                return Problem("Entity set 'AppDbContext.FriendsList' is null.");
            }
            var friendsList = await _context.FriendsList.FindAsync(id);
            if (friendsList != null)
            {
                _context.FriendsList.Remove(friendsList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Helper method to check if a friendship exists
        private bool FriendsListExists(int id)
        {
            return (_context.FriendsList?.Any(e => e.FriendshipId == id)).GetValueOrDefault();
        }
    }
}