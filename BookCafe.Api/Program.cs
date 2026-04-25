using BookCafe.Application.CQRS.Authors.Commands;
using BookCafe.Application.Interfaces.Infra;
using BookCafe.Application.Interfaces.Services;
using BookCafe.Application.Services;
using BookCafe.Domain;
using BookCafe.Domain.Entities;
using BookCafe.Domain.Repositories;
using BookCafe.Infrastructure;
using BookCafe.Infrastructure.Context;
using BookCafe.Infrastructure.Repositories;
using BookCafe.Infrastructure.Repository;
using BookCafe.Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Formatting.Compact;

var builder = WebApplication.CreateBuilder(args);



builder.Host.UseSerilog();
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Filter.ByIncludingOnly(e =>
    e.Properties.ContainsKey("SourceContext") &&
    e.Properties["SourceContext"].ToString().Contains("LogService"))  

    .WriteTo.File(new RenderedCompactJsonFormatter(),      
        path: "logs/BookCafe-.txt", 
        rollingInterval: RollingInterval.Day 
          )
    .CreateLogger();


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContextPool<ApplicationDbContext>((sp, options) =>
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
builder.Services.AddScoped<IBookService, GetBookServices>();
builder.Services.AddScoped<IBookService, SpecificBookServices>();
//builder.Services.AddKeyedScoped<IBookService, SpecificBookServices>("A");
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<IAppSetting, AppSettingsProvider>();
builder.Services.AddScoped(typeof(ILogService<>), typeof(LogService<>));
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
