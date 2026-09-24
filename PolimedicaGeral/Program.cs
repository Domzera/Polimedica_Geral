
using Microsoft.EntityFrameworkCore;
using PolimedicaGeral.Data;
using PolimedicaGeral.Interface;
using PolimedicaGeral.Repository;
using PolimedicaGeral.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IRoteiro, RoteiroRepository>();
builder.Services.AddScoped<CheckAddRoteiro>();
builder.Services.AddScoped<ChecaUpdate>();


//BD conection
builder.Services.AddDbContext<PolimedicaGeralDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PolimedicaGeralContext"));
});

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapGet("/pagina", () => Results.File("index.html", "text/html"));

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();


app.Run();