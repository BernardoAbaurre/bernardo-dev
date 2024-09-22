using bernardo_dev.Models.Domain.TicTacToes.Boards.Entities;
using bernardo_dev.Models.Domain.TicTacToes.Boards.Enums;
using bernardo_dev.Models.Domain.TicTacToes.Players.Entities;

namespace bernardo_dev.Repositories.TicTacToes.Players.Interfaces
{
    public interface IPlayersRepository
    {
        Task<Player?> GetByIdAsync(string connectionId);
        Task<Player> CreateAsync(Player player);
        Task UpdateAsync();
        Task DeleteAsync(Player player);
    }
}
