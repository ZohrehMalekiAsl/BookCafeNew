using BookCafe.Application.CQRS.Authors.Commands;
using BookCafe.Domain.Repositories;
using BookCafe.Infrastructure.Context;
using BookCafe.Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ApplicationDbContext>
    (option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    .UseLazyLoadingProxies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository, AuthorRepository>();
builder.Services.AddScoped<IMediator, Mediator>();
builder.Services.AddMediatR(x=>x.RegisterServicesFromAssembly(typeof(AddAuthorCommand).Assembly));

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
