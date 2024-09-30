using bernardo_dev.Models.Domain.TicTacToes.Boards.Entities;
using bernardo_dev.Models.Domain.TicTacToes.Boards.Enums;
using bernardo_dev.Models.Domain.TicTacToes.Boards.Services.Interfaces;
using bernardo_dev.Models.Domain.TicTacToes.Players.Entities;
using bernardo_dev.Repositories.TicTacToes.Boards.Interfaces;
using bernardo_dev.Repositories.TicTacToes.Players.Interfaces;

namespace bernardo_dev.Models.Domain.TicTacToes.Boards.Services
{
    public class BoardService : IBoardsService
    {
        private readonly IBoardsRepository boardsRepository;
        private readonly IPlayersService playersService;

        public BoardService(IBoardsRepository boardsRepository, IPlayersService playersService)
        {
            this.boardsRepository = boardsRepository;
            this.playersService = playersService;
        }
        public int[]? CheckWinner(Board board)
        {
            int[][] winningPatterns =
            {
                [0, 1, 2],
                [3, 4, 5],
                [6, 7, 8],
                [0, 3, 6],
                [1, 4, 7],
                [2, 5, 8],
                [0, 4, 8],
                [2, 4, 6] 
            };

            foreach (var pattern in winningPatterns)
            {
                FieldStatusEnum field1 = board.Fields[pattern[0]];
                FieldStatusEnum field2 = board.Fields[pattern[1]];
                FieldStatusEnum field3 = board.Fields[pattern[2]];

                if (field1 == field2 && field2 == field3 && field1 != FieldStatusEnum.Empty)
                {
                    return pattern; 
                }
            }

            if (board.Fields.All(f => f != FieldStatusEnum.Empty))
            {
                return [];
            }

            return null;
        }

        public async Task<Board> NewBoard()
        {
            Board board = new Board();
            await boardsRepository.CreateAsync(board);

            return board;
        }

        public async Task<Board> Play(int fieldIndex, Board board, Player player)
        {
            board.Fields[fieldIndex] = player.PlayerType;

            board.Turn = board.Turn == FieldStatusEnum.Cross ? FieldStatusEnum.Circle : FieldStatusEnum.Cross;

            await playersService.ChangeTurn(board);

            await boardsRepository.UpdateAsync(board);

            return board;
        }

        public async Task<Board> Validate(string boardId)
        {
            Board? board = await boardsRepository.GetByIdAsync(Guid.Parse(boardId));

            if(board == null)
            {
                throw new ArgumentException($"Board {boardId} was not found");
            }

            return board;
        }

        public async Task<Board> Restart(Board board)
        {
           board.Fields = [FieldStatusEnum.Empty, FieldStatusEnum.Empty, FieldStatusEnum.Empty,
               FieldStatusEnum.Empty, FieldStatusEnum.Empty, FieldStatusEnum.Empty,
               FieldStatusEnum.Empty, FieldStatusEnum.Empty, FieldStatusEnum.Empty];

           await boardsRepository.UpdateAsync(board);

            return board;
        }
    }
}
