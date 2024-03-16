using System.Collections.Generic;
using System.Threading.Tasks;
using OLE_WEBAPP.Models;

namespace OLE_WEBAPP.Interfaces
{
    public interface IPlayerServices
    {
        Task<Player> GetPlayerAsync(int playerId);

        Task<List<Player>> GetAllPlayersAsync();

        Task<Player> CreatePlayerAsync(Player player);

        Task<Player> UpdatePlayerAsync(int playerId, Player player);

        Task<bool> DeletePlayerAsync(int playerId);

        bool PlayerExists(int playerId);
    }
}