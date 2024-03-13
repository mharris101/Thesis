using Microsoft.EntityFrameworkCore;
using ThesisAPI.Models;
using FluentValidation;
using ThesisAPI.DTOs;
using ThesisAPI.Validators;
using ThesisAPI.Services.Interfaces;
using ThesisAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Dependency Injection
// Validators
builder.Services.AddScoped<IValidator<VideoCard>, VideoCardValidator>();
// Services
builder.Services.AddScoped<IVideoCardService, VideoCardService>();
builder.Services.AddScoped<IComputerService, ComputerService>();

builder.Services.AddDbContext<ThesisContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
