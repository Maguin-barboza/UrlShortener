using Microsoft.EntityFrameworkCore;
using UrlShortener.Command;
using UrlShortener.Data.Context;
using UrlShortener.Data.Repository;
using UrlShortener.Domain.Interfaces.Commands;
using UrlShortener.Domain.Interfaces.Queries;
using UrlShortener.Domain.Interfaces.Repositories;
using UrlShortener.Query;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddResponseCaching();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureService(builder.Services);
ConfigureContext(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseResponseCaching();

app.MapControllers();

app.Run();

void ConfigureService(IServiceCollection services)
{
    services.AddTransient<IUrlRepository, UrlRepository>();
    
    services.AddTransient<IUrlQuery, UrlQuery>();
    
    services.AddTransient<IShortenUrlCommand, ShortenUrlCommand>();
    services.AddTransient<IUrlAddCommand, UrlAddCommand>();

    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
}

void ConfigureContext(IServiceCollection services)
{
    string connectionString;

    connectionString = "Server=MAGNO-PC\\MSSQLSRVMAGNO;Database=UrlShortener;User Id=Dev;Password=devadmin;";
    services.AddDbContext<UrlShortContext>(context =>
        context.UseSqlServer(connectionString));
}