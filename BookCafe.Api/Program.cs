using AutoMapper;
using Azure.Core;
using BookCafe.Application.CQRS.Authors.Commands;
using BookCafe.Application.Interfaces.Infra;
using BookCafe.Application.Interfaces.Services;
using BookCafe.Application.Services;
using BookCafe.Domain.Repositories;
using BookCafe.Infrastructure;
using BookCafe.Infrastructure.Context;
using BookCafe.Infrastructure.Repositories;
using BookCafe.Infrastructure.Repository;
using BookCafe.Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
{
    var settings = sp.GetRequiredService<IAppSetting>();
    options.UseSqlServer(settings.DefaultConnection)
           .UseLazyLoadingProxies();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMediator, Mediator>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<IAppSetting, AppSettingsProvider>();
builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("Settings"));

builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(AddAuthorCommand).Assembly));

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
