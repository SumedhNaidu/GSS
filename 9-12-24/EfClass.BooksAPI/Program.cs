using EfClass.DataAccess;
using EfClass.DataAccess.Repositories;
using EfClass.Managers;
using EfClass.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IBooksRepository, BooksRepository>();
builder.Services.AddTransient(typeof(IRepository<>),typeof(BaseRepository<>));

builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<IBooksManager, BooksManager>();
builder.Services.AddTransient<IUsersManager, UsersManager>();

//Db 
builder.Services.AddDbContext<BookDBContext>(options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("DefaultConnection")));

//add auto mapper
builder.Services.AddAutoMapper(typeof(Program));

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
