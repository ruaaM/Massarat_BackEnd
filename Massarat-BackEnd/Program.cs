using Massarat.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Massarat_BackEnd.Services;
using Massarat_BackEnd.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer(connectionString));





builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
	options.User.RequireUniqueEmail = false;
	options.Password.RequiredLength = 6;
	options.Password.RequireUppercase = true;

}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddAuthentication(auth =>
//{
//	auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//	auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

//}).AddJwtBearer(options=>
//{
//	options.TokenValidationParameters = new TokenValidationParameters
//	{
//		ValidateAudience = true,
//		ValidateIssuer = true,
//		ValidAudience = "",
//		ValidIssuer = "",
//		RequireExpirationTime =true,
//		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is the key to use in API")),
//		ValidateIssuerSigningKey = true,
		
//	};
//});
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

//app.UseStatusCodePages();
//app.UseStatusCodePages(Text.Plain, "Status Code Page: {0}");


app.Run();
