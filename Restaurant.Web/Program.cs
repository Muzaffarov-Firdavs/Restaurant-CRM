using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Contexts;
using Restaurant.Service.Helpers;
using Restaurant.Service.Mappers;
using Restaurant.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<EmailVerification>();
builder.Services.AddScoped<PasswordHasher>();
builder.Services.AddCustomServices();


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
