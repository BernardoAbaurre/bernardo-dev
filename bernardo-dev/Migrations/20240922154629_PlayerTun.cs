using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bernardo_dev.Migrations
{
    /// <inheritdoc />
    public partial class PlayerTun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Turn",
                table: "TicTacToe_Player",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Turn",
                table: "TicTacToe_Player");
        }
    }
}
