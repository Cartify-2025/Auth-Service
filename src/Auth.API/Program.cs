using Auth.Application.Logging;
using Auth.Infrastructure.Logging;
using Auth.Infrastructure.Migrations;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Setup Serilog from appsettings.json
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog(); // Plug Serilog into the host

builder.Services.AddScoped(typeof(IAppLogger<>), typeof(SerilogAdapter<>));


// Run Liquibase
LiquibaseMigrator.Run();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
