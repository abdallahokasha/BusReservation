using BusReservation.Core;
using BusReservation.Core.Interfaces;
using BusReservation.DAL;
using BusReservation.DAL.Interfaces;
using BusReservation.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BusReservationDbContext> (options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("BusReservationConnectionString")));

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IReservationDal, ReservationDal>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();