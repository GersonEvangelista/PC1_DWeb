using Microsoft.EntityFrameworkCore;
using StoreDB_DOMAIN1.Core.Interfaces;
using StoreDB_DOMAIN1.Core.Services;
using StoreDB_DOMAIN1.Infrastructure.Data;
using StoreDB_DOMAIN1.Infrastructure.Repositories;
using UESAN.StoreDB.DOMAIN.Infrastructure.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _config = builder.Configuration;
var cnx = _config.GetConnectionString("DevConnection");
builder.Services
    .AddDbContext<StoreDbContext> //Importar using
    (options => options.UseSqlServer(cnx)); //Importar using 

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddSharedInfrastructure(_config);


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
