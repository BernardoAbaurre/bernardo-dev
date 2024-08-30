using bernardo_dev.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace bernardo_dev.Data
{
    public class BernardoDevDbContext : DbContext
    {
        public BernardoDevDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<WeatherType> WeatherTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

        }
    }
}
