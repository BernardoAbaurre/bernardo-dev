using bernardo_dev.Data;
using bernardo_dev.Hubs;
using bernardo_dev.Models.Domain.TicTacToes.Boards.Services;
using bernardo_dev.Models.Domain.TicTacToes.Boards.Services.Interfaces;
using bernardo_dev.Models.Domain.TicTacToes.Players.Services;
using bernardo_dev.Repositories.TicTacToes.Boards;
using bernardo_dev.Repositories.TicTacToes.Boards.Interfaces;
using bernardo_dev.Repositories.TicTacToes.Players;
using bernardo_dev.Repositories.TicTacToes.Players.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin() 
                   .AllowAnyMethod()  
                   .AllowAnyHeader(); 
        });
});

builder.Services.AddControllers()
.AddJsonOptions(options =>
 {
     options.JsonSerializerOptions.PropertyNamingPolicy = null;
 });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<BernardoDevDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BernardoDevConnectionString"));
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IBoardsRepository, BoardRepository>();
builder.Services.AddScoped<IBoardsService, BoardService>();
builder.Services.AddScoped<IPlayersRepository, PlayerRepository>();
builder.Services.AddScoped<IPlayersService, PlayerService>();

builder.Services.AddSignalR();

var app = builder.Build();

app.MapHub<TicTacToeHub>("/hub/tic-tac-toe");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
