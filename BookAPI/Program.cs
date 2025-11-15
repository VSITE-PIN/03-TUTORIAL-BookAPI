using BookAPI.Data;
using BookAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EF Core: registracija AppDbContext-a
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnString")
        ?? throw new InvalidOperationException("Connection string 'DefaultConnString' not found.")));

// Registracija servisa
builder.Services.AddScoped<BooksService>();
builder.Services.AddScoped<AuthorsService>();
builder.Services.AddScoped<PublisherService>();


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
