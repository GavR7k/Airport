using Airport.Application.Interfaces;
using Airport.Application.Services;
using Airport.Domain.Interfaces;
using Airport.Infrastructure.Persistence;
using Airport.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Enum сериализаци€ дл€ свагера чтобы вместо 0,1,2 видеть : Open,Closed...
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });


builder.Services.AddDbContext<AirportDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();

builder.Services.AddScoped<IGateService, GateService>();
builder.Services.AddScoped<IGateRepository, GateRepository>();

builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
builder.Services.AddScoped<IPassengerService, PassengerService>();




var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AirportDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
