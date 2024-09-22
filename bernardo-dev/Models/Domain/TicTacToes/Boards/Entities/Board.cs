using bernardo_dev.Models.Domain.TicTacToes.Boards.Enums;
using bernardo_dev.Models.Domain.TicTacToes.Players.Entities;

namespace bernardo_dev.Models.Domain.TicTacToes.Boards.Entities
{
    public class Board
    {
        public Guid Id { get; set; }
        public bool Playing { get; set; }
        public FieldStatusEnum Turn { get; set; } = FieldStatusEnum.Cross;
        public FieldStatusEnum[] Fields { get; set; } = [FieldStatusEnum.Empty, FieldStatusEnum.Empty, FieldStatusEnum.Empty, FieldStatusEnum.Empty, FieldStatusEnum.Empty, FieldStatusEnum.Empty, FieldStatusEnum.Empty, FieldStatusEnum.Empty, FieldStatusEnum.Empty];

        // Navigation properties
        public IList<Player> Players { get; set; } = new List<Player>();
    }
}
