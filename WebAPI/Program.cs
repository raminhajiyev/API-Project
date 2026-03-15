using FluentValidation;
using System.Reflection;
using WebAPI.Context;
using WebAPI.DTOs.MessageDTO;
using WebAPI.Entities;
using WebAPI.ValidationRules;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiContext>();

builder.Services.AddScoped<IValidator<CreateMessageDTO>, MessageValidator>();
builder.Services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

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
