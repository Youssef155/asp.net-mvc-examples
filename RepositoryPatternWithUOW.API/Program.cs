using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Repositories;
using RepositoryPatternWithUOW.EF;
using RepositoryPatternWithUOW.EF.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conString = builder.Configuration.GetConnectionString("default") ??
     throw new InvalidOperationException("Connection string 'default'" +
    " not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(conString));

// builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


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
