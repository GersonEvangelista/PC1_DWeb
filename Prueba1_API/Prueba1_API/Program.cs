using Microsoft.EntityFrameworkCore;
using Prueba1_DOMAIN.Core.Interfaces;
using Prueba1_DOMAIN.Core.Services;
using Prueba1_DOMAIN.Data;
using Prueba1_DOMAIN.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _config = builder.Configuration;
var cnx = _config.GetConnectionString("DevConnection");
builder.Services
    .AddDbContext<EventManagementDbContext> //Importar using
    (options => options.UseSqlServer(cnx)); //Importar using 

builder.Services.AddTransient<IEventsRepository, EventsRepository>();
builder.Services.AddTransient<IEventsService, EventsService>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
