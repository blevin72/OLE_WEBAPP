using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OLE_WEBAPP.Interfaces;
using OLE_WEBAPP.Models;

namespace OLE_WEBAPP.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerServices _playerServices;

        public PlayersController(IPlayerServices playerServices)
        {
            _playerServices = playerServices;
        }

        // Action method for displaying a list of players
        public async Task<IActionResult> Index()
        {
            var players = await _playerServices.GetAllPlayersAsync();
            return View(players);
        }

        // Action method for displaying details of a player
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _playerServices.GetPlayerAsync(id.Value);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // Action method for displaying the player creation form
        public IActionResult Create()
        {
            return View();
        }

        // Action method for handling the player creation form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,FirstName,LastName,Dob,Avatar")] Player player)
        {
            if (ModelState.IsValid)
            {
                await _playerServices.CreatePlayerAsync(player);
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        // Action method for displaying the player edit form
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _playerServices.GetPlayerAsync(id.Value);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // Action method for handling the player edit form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,FirstName,LastName,Dob,Avatar")] Player player)
        {
            if (id != player.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _playerServices.UpdatePlayerAsync(id, player);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_playerServices.PlayerExists(id))
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
            return View(player);
        }

        // Action method for displaying the player delete confirmation page
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _playerServices.GetPlayerAsync(id.Value);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // Action method for handling the player deletion
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _playerServices.DeletePlayerAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}