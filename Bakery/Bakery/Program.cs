using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUsersData, UsersData>();
builder.Services.AddScoped<IProductsServices, ProductsServices>();
builder.Services.AddScoped<IProductsData, ProductsData>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<ICategoriesData, CategoriesData>();
builder.Services.AddScoped<IorderServices, orderServices>();
builder.Services.AddScoped<IOrderData, OrderData>();


builder.Services.AddDbContext<UsersDBContext>(option =>
        option.UseSqlServer("Data Source = SRV2\\PUPILS; Initial Catalog = AdoNet; Integrated Security = True;Trust Server Certificate=True"));
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "My API V1");
    });
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
