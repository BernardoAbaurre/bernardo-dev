using bernardo_dev.Models.Domain.TicTacToes.Boards.Entities;
using bernardo_dev.Models.Domain.TicTacToes.Boards.Enums;
using bernardo_dev.Models.Domain.TicTacToes.Boards.Services.Interfaces;
using bernardo_dev.Models.Domain.TicTacToes.Players.Entities;
using bernardo_dev.Repositories.TicTacToes.Players.Interfaces;

namespace bernardo_dev.Models.Domain.TicTacToes.Players.Services
{
    public class PlayerService : IPlayersService
    {
        private readonly IPlayersRepository playersRepository;

        public PlayerService(IPlayersRepository boardsRepository)
        {
            this.playersRepository = boardsRepository;
        }

        public async Task DeletePlayer(string playerId)
        {
            Player player = await Validate(playerId);

            await playersRepository.DeleteAsync(player);
        }

        public Player GetInBoard(Board board, string playerId)
        {
            var guid = Guid.Parse(playerId);

            var player = board.Players.FirstOrDefault(p => p.Id == guid);

            if (player == null)
            {
                throw new ArgumentException($"No player was found");
            }

            return player;
        }

        public async Task<Player> NewPlayer(string name, Board board)
        {
            if(board.Players.Count == 2 )
            {
                throw new ArgumentException("This Board is already full");
            }

            FieldStatusEnum playerType = board.Players.Count > 0 ? FieldStatusEnum.Circle : FieldStatusEnum.Cross;
            bool turn = playerType == FieldStatusEnum.Cross;

            Player player = new Player(name, playerType, board.Id, turn);
            await playersRepository.CreateAsync(player);

            return player;
        }

        public async Task ChangeTurn(Board board)
        {
            board.Players[0].Turn = !board.Players[0].Turn;
            board.Players[1].Turn = !board.Players[1].Turn;

            await playersRepository.UpdateAsync();
        }  

        public async Task<Player> Validate(string playerId)
        {
            Player? player = await playersRepository.GetByIdAsync(playerId);

            if(player == null)
            {
                throw new ArgumentException($"Player {playerId} was not found");
            }

            return player;
        }

        
    }
}
