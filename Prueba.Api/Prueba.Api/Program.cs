using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Prueba.DataAccess.DbContextSqlServer;
using Prueba.Domains;
using Prueba.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<DbContextSs>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Register Services and Domains

builder.Services.AddServicesLayer();

builder.Services.AddDomainsLayer();

#endregion Register Services and Domains

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