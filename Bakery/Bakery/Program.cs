using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUsersData, UsersData>();
builder.Services.AddDbContext<BakeryDBContext>(options => options.UseSqlServer("Data Source=SRV2\\PUPILS; Initial Catalog=elishevaDB; Integrated Security=True; Trust Server Certificate=True"));
// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
