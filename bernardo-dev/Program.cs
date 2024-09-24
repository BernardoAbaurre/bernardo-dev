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
using Microsoft.Extensions.Logging.AzureAppServices;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("D:\\home\\LogFiles\\Application\\log-.txt", rollingInterval: RollingInterval.Day)
    .MinimumLevel.Information()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


builder.Services.Configure<AzureFileLoggerOptions>(options =>
{
    options.FileName = "logs-";
    options.FileSizeLimit = 50 * 1024;
    options.RetainedFileCountLimit = 5;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", builder =>
    {
        builder.WithOrigins("https://app-bernardo-dev-site-achuafb6ffexccdr.brazilsouth-01.azurewebsites.net", "http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
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

builder.Services.AddSignalR().AddAzureSignalR(options =>
{
    options.ConnectionString = builder.Configuration["Azure:SignalR:ConnectionString"];
});

var app = builder.Build();

app.MapHub<TicTacToeHub>("/hub/tic-tac-toe");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
