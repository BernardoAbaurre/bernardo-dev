using bernardo_dev.Models.Domain.TicTacToes.Boards.Entities;
using bernardo_dev.Models.Domain.TicTacToes.Boards.Enums;
using bernardo_dev.Models.Domain.TicTacToes.Players.Entities;

namespace bernardo_dev.Models.Domain.TicTacToes.Boards.Services.Interfaces
{
    public interface IPlayersService
    {
        Task<Player> Validate(string playerId);

        Task<Player> NewPlayer(string name, Board board);

        Player GetInBoard(Board board, string playerId);
        
        Task DeletePlayer(string playerId);

        Task ChangeTurn(Board board);
    }
}
