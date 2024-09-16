using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MoviesApi.Data;
using MoviesApi.Repositories.Abstracts;
using MoviesApi.Repositories.Concretes;
using MoviesApi.Services.Abstracts;
using MoviesApi.Services.Concretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddHttpClient<IRandomMoviesService, RandomMoviesService>();
builder.Services.AddScoped<IMovieRepository,EFMovieRepository>();
builder.Services.AddScoped<IMovieService,EFMovieService>();
builder.Services.AddHostedService<BackgroundWorkerService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<MoviesDbContext>(opt =>
{
    opt.UseSqlServer(connection);
});

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
