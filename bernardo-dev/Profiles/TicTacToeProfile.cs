using AutoMapper;
using bernardo_dev.Models.Domain.TicTacToes.Boards.Entities;
using bernardo_dev.Models.Domain.TicTacToes.Players.Entities;
using bernardo_dev.Models.DTO.TicTacToes.Boards;
using bernardo_dev.Models.DTO.TicTacToes.Players;

namespace bernardo_dev.Profiles
{
    public class TicTacToeProfile : Profile
    {
        public TicTacToeProfile()
        {
            CreateMap<Board, BoardResponse>();
            CreateMap<Player, PlayerResponse>();
        }
    }
}
