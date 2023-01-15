using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using RestEase;
using TriviaBotApi.Data;
using TriviaBotApi.Services.ClueServices;
using TriviaBotApi.Services.GameStatsServices;
using TriviaBotApi.Services.UserServices;

var builder = WebApplication.CreateBuilder(args);

// Add rest client for IClueService
var clueServiceClient = RestClient.For<IClueService>("https://jservice.io/api/");

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();

builder.Services.AddSingleton(clueServiceClient);
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGameStatsService, GameStatsService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
