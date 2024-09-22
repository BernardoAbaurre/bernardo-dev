using bernardo_dev.Models.Domain.TicTacToes.Boards.Entities;
using bernardo_dev.Models.Domain.TicTacToes.Boards.Enums;
using bernardo_dev.Models.Domain.TicTacToes.Players.Entities;

namespace bernardo_dev.Models.Domain.TicTacToes.Boards.Services.Interfaces
{
    public interface IBoardsService
    {
        Task<Board> Play(int fieldIndex, Board board, Player player);

        Task<Board> Validate(string boardId);

        int[] CheckWinner(Board board);

        Task<Board> NewBoard();
        Task<Board> Restart(Board board);
    }
}
