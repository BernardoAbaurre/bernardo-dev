using bernardo_dev.Data;
using bernardo_dev.Models.Domain.TicTacToes.Boards.Entities;
using bernardo_dev.Repositories.TicTacToes.Boards.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bernardo_dev.Repositories.TicTacToes.Boards
{
    public class BoardRepository : IBoardsRepository
    {
        private readonly BernardoDevDbContext bernardoDevDbContext;

        public BoardRepository(BernardoDevDbContext bernardoDevDbContext)
        {
            this.bernardoDevDbContext = bernardoDevDbContext;
        }

        public async Task<Board> CreateAsync(Board board)
        {
            await bernardoDevDbContext.TicTacToeBoards.AddAsync(board);
            await bernardoDevDbContext.SaveChangesAsync();
            return board;
        }

        public async Task<Board?> GetByIdAsync(Guid id)
        {
            return await bernardoDevDbContext.TicTacToeBoards.Include("Players").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Board?> UpdateAsync(Board board)
        {
            await bernardoDevDbContext.SaveChangesAsync();

            return board;
        }
    }
}
