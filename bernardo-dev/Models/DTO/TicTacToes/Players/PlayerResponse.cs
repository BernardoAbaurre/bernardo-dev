using bernardo_dev.Models.Domain.TicTacToes.Boards.Enums;
using bernardo_dev.Models.DTO.TicTacToes.Boards;

namespace bernardo_dev.Models.DTO.TicTacToes.Players
{
    public class PlayerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Connected { get; set; }
        public FieldStatusEnum PlayerType { get; set; }
        public Guid BoardId { get; set; }
        public bool Turn { get; set; }
    }
}
