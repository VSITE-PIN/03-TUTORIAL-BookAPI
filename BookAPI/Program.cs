

using Microsoft.EntityFrameworkCore;
using BookAPI.Services;
using BookAPI.Data;
using Microsoft.AspNetCore.Mvc;
using BookAPI.ViewModels;
var builder = WebApplication.CreateBuilder(args);






builder.Services.AddDbContext<AppDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnString")?? throw new InvalidOperationException("Connection string DefaultConnString not found.")));

builder.Services.AddScoped<PublishersService>();
builder.Services.AddScoped<AuthorsService>();
builder.Services.AddScoped<BooksService>();

// Add services to the container.

builder.Services.AddControllers();
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

public class BooksController : ControllerBase
{
	public BooksService BooksService { get; set; }
	public BooksController(BooksService booksService)
	{
		BooksService = booksService;
	}
	[HttpPost]
	public IActionResult AddBook([FromBody] BookVM book)
	{
		BooksService.AddBook(book);
		return Ok();
	}
}