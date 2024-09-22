using bernardo_dev.Models.Domain.TicTacToes.Boards.Entities;
using bernardo_dev.Models.Domain.TicTacToes.Boards.Enums;
using System.ComponentModel.DataAnnotations;

namespace bernardo_dev.Models.Domain.TicTacToes.Players.Entities
{
    public class Player
    {
        public Player(string name, FieldStatusEnum playerType, Guid boardId, bool turn)
        {
            Id = Guid.NewGuid();
            Name = name;
            Connected = false;
            PlayerType = playerType;
            BoardId = boardId;
            Turn = turn;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Connected { get; set; }
        public FieldStatusEnum PlayerType { get; set; }
        public Guid BoardId { get; set; }
        public bool Turn { get; set; }

        // Navigation property to Board
        public Board Board { get; set; }

    }
}
