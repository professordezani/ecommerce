var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapControllerRoute("default", "/{controller=Produto}/{action=Index}/{id?}");

app.UseStaticFiles();

app.Run();