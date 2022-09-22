using CustomerManagementEF.Contexts;
using CustomerManagementEF.Entities;
using CustomerManagementEF.Interfaces;
using CustomerManagementEF.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IService<Customer>,CustomerService>();
builder.Services.AddTransient<IService<Address>,AddressService>();
builder.Services.AddTransient<IService<Note>,NoteService>();

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
