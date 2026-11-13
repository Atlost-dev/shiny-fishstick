using Microsoft.EntityFrameworkCore;
using DSW_3P_PR02.Repositories;
using DSW_3P_PR02.Services;
using DSW_3P_PR02.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IEventoRepository, EventoSQLRepository>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
  app.UseSwaggerUI(options =>
  {
    options.SwaggerEndpoint("/openapi/v1.json", "Eventos");
  });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
