using bernardo_dev.Models.Domain.TicTacToes.Players.Entities;
using bernardo_dev.Models.DTO.TicTacToes.Players;
using Microsoft.VisualBasic.FileIO;

namespace bernardo_dev.Models.DTO.TicTacToes.Boards
{
    public class BoardResponse
    {
        public string Id { get; set; }
        public FieldType[] Fields { get; set; }
        public bool Playing { get; set; }
        public FieldType Turn { get; set; }
        public IList<PlayerResponse> Players { get; set; }
    }
}
