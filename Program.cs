using Ecommerce.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
// builder.Services.AddDbContext<DbEcommerce>(options =>
//     options.UseInMemoryDatabase("InMemoryDb"));
builder.Services.AddDbContext<DbEcommerce>(options =>
    options.UseSqlite("Data Source=ecommerce.db"));

var app = builder.Build();

app.MapControllerRoute("default", "/{controller=Produto}/{action=Index}/{id?}");

app.UseStaticFiles();

app.Run();