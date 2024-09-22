using bernardo_dev.Models.Domain.TicTacToes.Boards.Entities;
using bernardo_dev.Models.Domain.TicTacToes.Boards.Enums;

namespace bernardo_dev.Repositories.TicTacToes.Boards.Interfaces
{
    public interface IBoardsRepository
    {
        Task<Board?> GetByIdAsync(Guid id);
        Task<Board> CreateAsync(Board board);
        Task<Board?> UpdateAsync(Board board);
    }
}
