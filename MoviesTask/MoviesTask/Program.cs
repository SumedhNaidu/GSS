using AccessData.Context;
using AccessData.Mapping;
using Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MoviesDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IServiceMovies, MoviesService>();
builder.Services.AddScoped<IRepositoryMovies, MoviesRepository>();
builder.Services.AddAutoMapper(typeof(MovieMapping));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
