using Microsoft.EntityFrameworkCore;
using MusicHaven;
using MusicHaven.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Servicios que seran utilizados en los controladores.
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<ITrackService, TrackService>();

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
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
