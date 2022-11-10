using create_tests.WebAPI.AppConfiguration.ApplicationExtensions;
using create_tests.WebAPI.AppConfiguration.ServicesExtensions;
using Serilog;
using create_test.Entities;
using Microsoft.EntityFrameworkCore;
using create_test.Repository;

var configuration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", optional: false)
.Build();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddSerilogConfiguration(); //Add serilog
// builder.Services.AddDbContextConfiguration(configuration);
builder.Services.AddDbContext <Context> (o => o.UseNpgsql(builder.Configuration.GetConnectionString("Context")));

builder.Services.AddVersioningConfiguration(); //add api versioning
builder.Services.AddControllers();
builder.Services.AddSwaggerConfiguration(); //add swagger configuration

builder.Services.AddScoped<DbContext, Context>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

app.UseSerilogConfiguration(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration(); //use swagger
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();