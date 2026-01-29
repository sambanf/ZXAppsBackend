using Microsoft.EntityFrameworkCore;
using ZXAppsBackend.Domain.Interfaces;
using ZXAppsBackend.Infrastructure;
using ZXAppsBackend.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));

// Register repository 
builder.Services.AddScoped<IOperatorRepository, OperatorRepository>();

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers(); 

app.Run();
