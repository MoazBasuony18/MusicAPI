using Microsoft.EntityFrameworkCore;
using MusicAPI.BL.IRepository;
using MusicAPI.BL.Repository;
using MusicAPI.Configurations;
using MusicAPI.Models;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File(path: "G:\\Web Elgendy\\Api\\MusicAPI\\logs\\log-.txt",
    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
    rollingInterval: RollingInterval.Day,
    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information).CreateLogger();
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperInitlizer));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddCors(a =>
{
    a.AddPolicy("allowAll", newBuilder =>
    newBuilder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
});
builder.Services.AddDbContext<MusicDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Host.UseSerilog();
var app = builder.Build();

try
{
    Log.Information("Application is starting");
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseCors("allowAll");
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception)
{
    Log.Fatal("Application is failed to start");
}
finally
{
    Log.CloseAndFlush();
}
// Configure the HTTP request pipeline.


