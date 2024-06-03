using AuthService.Data;
using AuthService.Extensions;
using AuthService.Models;
using AuthService.Swagger;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDoc();

// Add Authentication
builder.Services.AddAuthentication()
    .AddCookie(IdentityConstants.ApplicationScheme);
    //.AddBearerToken(IdentityConstants.BearerScheme);


// Add Authorization
builder.Services.AddAuthorization();

// Configure DBContext
builder.Services.AddDbContext<AppDBContext>(opt => opt.UseSqlite("DataSource=appdata.db"));

// Add IdentityCore
builder.Services
    .AddIdentityCore<User>()
    .AddEntityFrameworkStores<AppDBContext>()
    .AddApiEndpoints();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable Identity APIs
app.CustomMapIdentityApi<User>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

