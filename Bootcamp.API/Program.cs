using Bootcamp.API.Filters;
using Bootcamp.API.Middlewares;
using Bootcamp.API.Repositories;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers(option=>option.Filters.Add(new ValidateFilter())).AddFluentValidation(x => x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.Configure<ApiBehaviorOptions>(option =>
        {
            option.SuppressModelStateInvalidFilter = true;
        });


        builder.Services.AddScoped<NotFoundProductFilter>();
        //builder.Services.AddScoped<IProductRepository, ProductRepository>();
        //builder.Services.AddScoped<ProductService>();

        builder.Services.AddScoped<IProductRepository, ProductRepository>();



        builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

        builder.Services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(builder.Configuration.GetConnectionString("Postgresql")));

        //builder.Services.AddScoped<IDbTransaction>(sp =>
        //{

        //    var connection = sp.GetRequiredService<IDbConnection>();
        //    connection.Open();
        //    return connection.BeginTransaction();


        //});


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseMiddleware<IPAddressControlMiddleware>();
        app.UseGlobalExceptionMiddleware();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}