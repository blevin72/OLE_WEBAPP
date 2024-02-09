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
    public class FriendRequestsController : Controller
    {
        private readonly AppDbContext _context;

        public FriendRequestsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: FriendRequests
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.FriendRequests.Include(f => f.Receiver).Include(f => f.Sender);
            return View(await appDbContext.ToListAsync());
        }

        // GET: FriendRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FriendRequests == null)
            {
                return NotFound();
            }

            var friendRequest = await _context.FriendRequests
                .Include(f => f.Receiver)
                .Include(f => f.Sender)
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (friendRequest == null)
            {
                return NotFound();
            }

            return View(friendRequest);
        }

        // GET: FriendRequests/Create
        public IActionResult Create()
        {
            ViewData["ReceiverId"] = new SelectList(_context.Accounts, "Id", "Id");
            ViewData["SenderId"] = new SelectList(_context.Accounts, "Id", "Id");
            return View();
        }

        // POST: FriendRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestId,SenderId,ReceiverId,RequestTimeStamp")] FriendRequest friendRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(friendRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReceiverId"] = new SelectList(_context.Accounts, "Id", "Id", friendRequest.ReceiverId);
            ViewData["SenderId"] = new SelectList(_context.Accounts, "Id", "Id", friendRequest.SenderId);
            return View(friendRequest);
        }

        // GET: FriendRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FriendRequests == null)
            {
                return NotFound();
            }

            var friendRequest = await _context.FriendRequests.FindAsync(id);
            if (friendRequest == null)
            {
                return NotFound();
            }
            ViewData["ReceiverId"] = new SelectList(_context.Accounts, "Id", "Id", friendRequest.ReceiverId);
            ViewData["SenderId"] = new SelectList(_context.Accounts, "Id", "Id", friendRequest.SenderId);
            return View(friendRequest);
        }

        // POST: FriendRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestId,SenderId,ReceiverId,RequestTimeStamp")] FriendRequest friendRequest)
        {
            if (id != friendRequest.RequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(friendRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FriendRequestExists(friendRequest.RequestId))
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
            ViewData["ReceiverId"] = new SelectList(_context.Accounts, "Id", "Id", friendRequest.ReceiverId);
            ViewData["SenderId"] = new SelectList(_context.Accounts, "Id", "Id", friendRequest.SenderId);
            return View(friendRequest);
        }

        // GET: FriendRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FriendRequests == null)
            {
                return NotFound();
            }

            var friendRequest = await _context.FriendRequests
                .Include(f => f.Receiver)
                .Include(f => f.Sender)
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (friendRequest == null)
            {
                return NotFound();
            }

            return View(friendRequest);
        }

        // POST: FriendRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FriendRequests == null)
            {
                return Problem("Entity set 'AppDbContext.FriendRequests'  is null.");
            }
            var friendRequest = await _context.FriendRequests.FindAsync(id);
            if (friendRequest != null)
            {
                _context.FriendRequests.Remove(friendRequest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FriendRequestExists(int id)
        {
          return (_context.FriendRequests?.Any(e => e.RequestId == id)).GetValueOrDefault();
        }
    }
}
