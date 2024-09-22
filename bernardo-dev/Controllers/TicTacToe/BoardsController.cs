using AutoMapper;
using bernardo_dev.Models.Domain.TicTacToes.Boards.Entities;
using bernardo_dev.Models.Domain.TicTacToes.Boards.Services.Interfaces;
using bernardo_dev.Models.DTO.TicTacToes.Boards;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bernardo_dev.Controllers.TicTacToe
{
    [Route("api/tic-tac-toe/boards")]
    [ApiController]
    public class BoardsController : ControllerBase
    {
        private readonly IBoardsService boardsService;
        private readonly IMapper mapper;

        public BoardsController(IBoardsService boardsService, IMapper mapper)
        {
            this.boardsService = boardsService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<BoardResponse>> NewBoard()
        {
            Board board = await boardsService.NewBoard();

            return Ok(mapper.Map<BoardResponse>(board));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BoardResponse>> GetById(string id)
        {
            Board board = await boardsService.Validate(id);

            return Ok(mapper.Map<BoardResponse>(board));
        }
    }
}
