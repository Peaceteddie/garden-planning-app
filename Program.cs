using DotNetEnv;
using garden_planning_app.Components;
using Microsoft.EntityFrameworkCore;
using Models;

Env.Load("./.env");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddDbContext<GardenContext>(dbConfig);

var app = builder.Build();

if (app.Environment.IsDevelopment() && app.Services.CreateScope().ServiceProvider.GetService<GardenContext>() is GardenContext db)
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();

static void dbConfig(DbContextOptionsBuilder options) =>
    options.UseNpgsql(GetConnectionString());

static string GetConnectionString() => @$"
    Host={Env.GetString("POSTGRES_HOST")};
    Port={Env.GetString("POSTGRES_PORT")};
    Database={Env.GetString("POSTGRES_DATABASE")};
    Username={Env.GetString("POSTGRES_USER")};
    Password={Env.GetString("POSTGRES_PASSWORD")};";
