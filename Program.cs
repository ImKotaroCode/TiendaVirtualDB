using Microsoft.EntityFrameworkCore;
using MiTiendaVirtual.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Cadena Conexión AddDbContext
builder.Services.AddDbContext<TiendaVirtualDbContext>(Options => Options.UseSqlServer(
builder.Configuration.GetConnectionString("TiendaVirtualDBConn")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
