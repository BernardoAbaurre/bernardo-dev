using bernardo_dev.Models.Domain.TicTacToes.Boards.Entities;
using bernardo_dev.Models.Domain.TicTacToes.Players.Entities;
using bernardo_dev.Models.Domain.Weathers;
using Microsoft.EntityFrameworkCore;

namespace bernardo_dev.Data
{
    public class BernardoDevDbContext : DbContext
    {
        public BernardoDevDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<WeatherType> WeatherTypes { get; set; }
        public DbSet<Board> TicTacToeBoards { get; set; }
        public DbSet<Player> TicTacToePlayers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var weatherTypes = new List<WeatherType>()
            { 
                new WeatherType()
                {
                    Id = Guid.Parse("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"),
                    Description = "Freezing"
                },
                new WeatherType()
                {
                    Id = Guid.Parse("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"),
                    Description = "Chilly"
                },
            };

            modelBuilder.Entity<WeatherType>().HasData(weatherTypes);
            modelBuilder.Entity<Board>().ToTable("TicTacToe_Board");

            modelBuilder.Entity<Player>()
                .ToTable("TicTacToe_Player")
                .HasOne(p => p.Board)
                .WithMany(b => b.Players)
                .HasForeignKey(p => p.BoardId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
