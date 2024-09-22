using bernardo_dev.Data;
using bernardo_dev.Models.Domain.TicTacToes.Players.Entities;
using bernardo_dev.Repositories.TicTacToes.Players.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bernardo_dev.Repositories.TicTacToes.Players
{
    public class PlayerRepository : IPlayersRepository
    {
        private readonly BernardoDevDbContext bernardoDevDbContext;

        public PlayerRepository(BernardoDevDbContext bernardoDevDbContext)
        {
            this.bernardoDevDbContext = bernardoDevDbContext;
        }

        public async Task<Player> CreateAsync(Player board)
        {
            await bernardoDevDbContext.TicTacToePlayers.AddAsync(board);
            await bernardoDevDbContext.SaveChangesAsync();
            return board;
        }

        public async Task DeleteAsync(Player player)
        {
            bernardoDevDbContext.TicTacToePlayers.Remove(player);
            await bernardoDevDbContext.SaveChangesAsync();
        }

        public async Task<Player?> GetByIdAsync(string playerId)
        {
            return await bernardoDevDbContext.TicTacToePlayers.FirstOrDefaultAsync(x => x.Id == Guid.Parse(playerId));
        }

        public async Task UpdateAsync()
        {
            await bernardoDevDbContext.SaveChangesAsync();

        }
    }
}
