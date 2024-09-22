using AutoMapper;
using bernardo_dev.Models.Domain.TicTacToes.Boards.Entities;
using bernardo_dev.Models.Domain.TicTacToes.Boards.Services.Interfaces;
using bernardo_dev.Models.DTO.TicTacToes.Players;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bernardo_dev.Controllers.TicTacToe
{
    [Route("api/tic-tac-toe/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayersService playersService;
        private readonly IBoardsService boardsService;
        private readonly IMapper mapper;

        public PlayersController(IPlayersService playersService, IBoardsService boardsService, IMapper mapper)
        {
            this.playersService = playersService;
            this.boardsService = boardsService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<PlayerResponse>> NewPlayer([FromBody] PlayerNewRequest request)
        {
            Board board = await boardsService.Validate(request.BoardId);

            var player = await playersService.NewPlayer(request.Name, board);

            return Ok(mapper.Map<PlayerResponse>(player));
        }
    }
}
