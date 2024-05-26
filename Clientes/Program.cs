using Microsoft.EntityFrameworkCore;
using Clientes.Models;

var builder = WebApplication.CreateBuilder(args);

// Configura el contexto de la base de datos
builder.Services.AddDbContext<ClientesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ClientesContext")));

// Otros servicios
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
