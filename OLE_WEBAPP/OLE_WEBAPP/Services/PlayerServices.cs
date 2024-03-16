using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OLE_WEBAPP.Data;
using OLE_WEBAPP.Interfaces;
using OLE_WEBAPP.Models;

namespace OLE_WEBAPP.Services
{
    public class PlayerServices : IPlayerServices
    {
        private readonly AppDbContext _dbContext;
        // constructor injects instance of AppDbContext to interact with DB and perform CRUD
        public PlayerServices(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Retrieves a player by player ID asynchronously
        public async Task<Player> GetPlayerAsync(int playerId)
        {
            return await _dbContext.Players
                .Include(p => p.Account) // Include related account information
                .FirstOrDefaultAsync(p => p.Id == playerId);
        }

        // Retrieves all players asynchronously
        public async Task<List<Player>> GetAllPlayersAsync()
        {
            return await _dbContext.Players.ToListAsync();
        }

        // Creates a new player asynchronously
        public async Task<Player> CreatePlayerAsync(Player player)
        {
            _dbContext.Players.Add(player);
            await _dbContext.SaveChangesAsync();
            return player;
        }

        // Updates an existing player asynchronously
        public async Task<Player> UpdatePlayerAsync(int playerId, Player player)
        {
            var existingPlayer = await _dbContext.Players.FirstOrDefaultAsync(p => p.Id == playerId);
            if (existingPlayer != null)
            {
                // Update existingPlayer properties
                existingPlayer.FirstName = player.FirstName;
                existingPlayer.LastName = player.LastName;
                // Update other properties as needed

                await _dbContext.SaveChangesAsync();
            }
            return existingPlayer;
        }

        // Deletes a player asynchronously
        public async Task<bool> DeletePlayerAsync(int playerId)
        {
            var playerToDelete = await _dbContext.Players.FirstOrDefaultAsync(p => p.Id == playerId);
            if (playerToDelete != null)
            {
                _dbContext.Players.Remove(playerToDelete);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public bool PlayerExists(int playerId)
        {
            return _dbContext.Players.Any(p => p.Id == playerId);
        }
    }
}