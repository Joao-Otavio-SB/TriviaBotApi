using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RestEase;
using Swashbuckle.AspNetCore.Filters;
using TriviaBotApi.Data;
using TriviaBotApi.Services.AuthServices;
using TriviaBotApi.Services.ClueServices;
using TriviaBotApi.Services.GameStatsServices;
using TriviaBotApi.Services.UserServices;

var builder = WebApplication.CreateBuilder(args);

// Add rest client for IClueService
var clueServiceClient = RestClient.For<IClueService>("https://jservice.io/api/");

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("ApiSettings:Token").Value)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();

builder.Services.AddSwaggerGen(config =>
{
    config.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Authorization header using bearer scheme",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    config.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddSingleton(clueServiceClient);
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGameStatsService, GameStatsService>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
