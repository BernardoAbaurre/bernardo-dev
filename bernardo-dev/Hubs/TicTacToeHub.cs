using AutoMapper;
using Azure;
using bernardo_dev.Models.Domain.TicTacToes.Boards.Entities;
using bernardo_dev.Models.Domain.TicTacToes.Boards.Enums;
using bernardo_dev.Models.Domain.TicTacToes.Boards.Services.Interfaces;
using bernardo_dev.Models.Domain.TicTacToes.Players.Entities;
using bernardo_dev.Models.DTO.TicTacToes.Boards;
using bernardo_dev.Repositories.TicTacToes.Boards.Interfaces;
using bernardo_dev.Repositories.TicTacToes.Players.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.Collections.Concurrent;

namespace bernardo_dev.Hubs
{
    public class TicTacToeHub : Hub
    {
        private readonly IBoardsService boardsService;
        private readonly IBoardsRepository boardsRepository;
        private readonly IMapper mapper;
        private readonly IPlayersService playersService;
        private readonly IPlayersRepository playersRepository;
        private readonly ILogger<TicTacToeHub> logger;

        public TicTacToeHub(IBoardsService boardsService, IBoardsRepository boardsRepository, IMapper mapper, IPlayersService playersService, IPlayersRepository playersRepository, ILogger<TicTacToeHub> logger)
        {
            this.boardsService = boardsService;
            this.boardsRepository = boardsRepository;
            this.mapper = mapper;
            this.playersService = playersService;
            this.playersRepository = playersRepository;
            this.logger = logger;
        }

        public async Task JoinBoard(string boardId, string playerId)
        {
            logger.LogInformation("Join log");

            Board board = await boardsService.Validate(boardId);
            Player player = await playersService.Validate(playerId);

            player.Connected = true;
            await playersRepository.UpdateAsync();

            var guid = Guid.Parse(boardId);

            var response = mapper.Map<BoardResponse>(board);

            await Clients.Group(boardId).SendAsync("ReceiveUpdateBoard", response);

            await Groups.AddToGroupAsync(Context.ConnectionId, boardId);
        }

        public async Task LeaveBoard(string playerId, string boardId)
        {
            await playersService.DeletePlayer(playerId);

            var board = await boardsService.Validate(boardId);

            var response = mapper.Map<BoardResponse>(board);

            await Clients.Group(boardId).SendAsync("ReceiveUpdateBoard", response);

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, boardId);
        }

        public async Task Play(string boardId, int fieldIndex, string playerId)
        {
            logger.LogInformation("Play log");
            Console.WriteLine("Played: " + Context.ConnectionId);
            Board board = await boardsService.Validate(boardId);
            Player player = await playersService.Validate(playerId);

            var boardResult = await boardsService.Play(fieldIndex, board, player);

            var response = mapper.Map<BoardResponse>(boardResult);

            await Clients.Group(boardId).SendAsync("ReceiveUpdateBoard", response);
        }

        public async Task Restart(string boardId)
        {
            logger.LogInformation("Restart log");
            Console.WriteLine("Restarted: " + Context.ConnectionId);
            Board board = await boardsService.Validate(boardId);

            await boardsService.Restart(board);

            var response = mapper.Map<BoardResponse>(board);

            await Clients.Group(boardId).SendAsync("ReceiveUpdateBoard", response);
        }

        public override async Task OnConnectedAsync()
        {
            logger.LogInformation("Connected log");
            Console.WriteLine("Connected: " + Context.ConnectionId);
            //Board? board = await boardsService.GetByPlayerAsync(Context.ConnectionId);

            //if (board != null)
            //{
            //    Player player = await playersService.Validate(Context.ConnectionId);

            //    player.Connected = true;

            //    await playersRepository.UpdateAsync(player);

            //    await Clients.Group(board.Id.ToString()).SendAsync("ReceiveUpdateBoard", player);
            //}

            await base.OnConnectedAsync();
        }

        //public async override Task OnDisconnectedAsync(Exception? exception)
        //{
        //    Board? board = await boardsService.GetByPlayerAsync(Context.ConnectionId);

        //    if (board != null)
        //    {
        //        Player player = await playersService.Validate(Context.ConnectionId);

        //        player.Connected = false;

        //        await playersRepository.UpdateAsync(player);

        //        await Clients.Group(board.Id.ToString()).SendAsync("ReceiveUpdateBoard", player);
        //    }

        //    await base.OnDisconnectedAsync(exception);
        //}
    }
}
