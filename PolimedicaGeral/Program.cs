
using Microsoft.EntityFrameworkCore;
using PolimedicaGeral.Data;
using PolimedicaGeral.Interface;
using PolimedicaGeral.Repository;
using PolimedicaGeral.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(); // Essa linha de código é para fazer a API aceitar conexões da mesma rede.(O front).
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
app.MapGet("/", () => Results.File("index.html", "text/html"));

app.UseHttpsRedirection();
app.UseRouting();
//Esta é a configuração que faz o front ser capaz de se conectar com a API na mesma rede.
app.UseCors(options =>
    options.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.MapControllers();


app.Run();