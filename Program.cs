using Microsoft.EntityFrameworkCore;
using MusicHaven;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var conString = builder.Configuration.GetConnectionString("MusicHavenDatabase") ??
    throw new InvalidOperationException("String de conexion 'MusicHavenDatabase' no encontrado.");
Console.WriteLine(conString);

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<MusicContext>(options => 
    options.UseNpgsql(conString));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
