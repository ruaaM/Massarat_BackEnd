using Massarat.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer(connectionString));
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	//app.UseExceptionHandler("/Error");
}
//if (!app.Environment.IsDevelopment())
//{
//	app.UseExceptionHandler("/error");
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.UseStatusCodePages();
//app.UseStatusCodePages(Text.Plain, "Status Code Page: {0}");


app.Run();
