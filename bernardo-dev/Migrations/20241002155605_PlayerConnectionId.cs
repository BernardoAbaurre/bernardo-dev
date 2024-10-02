using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bernardo_dev.Migrations
{
    /// <inheritdoc />
    public partial class PlayerConnectionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConnectionId",
                table: "TicTacToe_Player",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectionId",
                table: "TicTacToe_Player");
        }
    }
}
