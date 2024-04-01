using coreWebApiProject.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//inject into our controllers to  with communicate DB Set
builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    {
        // Configuration will take the connection string from the database
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    }); // Next in ApplicationDbContext for reading the contexts value

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); //middleware

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
