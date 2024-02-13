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

        public FriendsListController(AppDbContext context)
        {
            _context = context;
        }

        // GET: FriendsList
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.FriendsList.Include(f => f.Account1).Include(f => f.Account2);
            return View(await appDbContext.ToListAsync());
        }

        // GET: FriendsList/Details/5
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

        // GET: FriendsList/Create
        public IActionResult Create()
        {
            ViewData["Account1Id"] = new SelectList(_context.Accounts, "Id", "Id");
            ViewData["Account2Id"] = new SelectList(_context.Accounts, "Id", "Id");
            return View();
        }

        // POST: FriendsList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FriendshipId,Account1Id,Account2Id,FriendshipTimeStamp")] FriendsList friendsList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(friendsList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Account1Id"] = new SelectList(_context.Accounts, "Id", "Id", friendsList.Account1Id);
            ViewData["Account2Id"] = new SelectList(_context.Accounts, "Id", "Id", friendsList.Account2Id);
            return View(friendsList);
        }

        // GET: FriendsList/Edit/5
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
            ViewData["Account1Id"] = new SelectList(_context.Accounts, "Id", "Id", friendsList.Account1Id);
            ViewData["Account2Id"] = new SelectList(_context.Accounts, "Id", "Id", friendsList.Account2Id);
            return View(friendsList);
        }

        // POST: FriendsList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: FriendsList/Delete/5
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

        // POST: FriendsList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FriendsList == null)
            {
                return Problem("Entity set 'AppDbContext.FriendsList'  is null.");
            }
            var friendsList = await _context.FriendsList.FindAsync(id);
            if (friendsList != null)
            {
                _context.FriendsList.Remove(friendsList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FriendsListExists(int id)
        {
          return (_context.FriendsList?.Any(e => e.FriendshipId == id)).GetValueOrDefault();
        }
    }
}
