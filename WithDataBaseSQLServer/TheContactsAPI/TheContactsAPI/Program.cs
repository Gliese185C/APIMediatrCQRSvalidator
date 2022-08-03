using Microsoft.EntityFrameworkCore;
using MediatR;
using Persistence.Context;
using Application.Contacts.AddContact;
using System.Reflection;
using FluentValidation.AspNetCore;
using Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(c => c.RegisterValidatorsFromAssembly(typeof(AddContactCommand).GetTypeInfo().Assembly));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ContactsAPIDbContext>(options => options.UseInMemoryDatabase("ContactsDb"));
builder.Services.AddDbContext<ContactsAPIDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("ContactsApiConnectionString")));
builder.Services.AddMediatR(typeof(AddContactCommand));



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
