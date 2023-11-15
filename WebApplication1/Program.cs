using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApplication1.Data;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false)
    .Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews()
  .AddJsonOptions(options =>
  options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("db1")));

builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<AutorizacijaSwaggerHeader>();
});

builder.Services.AddCors();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(
          options => options
          .SetIsOriginAllowed(x => _ = true)
          .AllowAnyMethod()
          .AllowAnyHeader()
          .AllowCredentials());

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
