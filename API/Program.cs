using Api.Domain.Interfaces;
using Api.Domain.Services;
using Api.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

public class Program 
{
    public static void Main (String[] args) 
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<DatabaseContext>(options => 
            {
                options.UseMySql(builder.Configuration.GetConnectionString("Mysql"),
                ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("Mysql")));
            }
        );

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        builder.Services.AddScoped<ProjectsInterface, ProjectsServices>();
        builder.Services.AddScoped<ProjectsCategoryInterface, ProjectsCategoryServices>();
        builder.Services.AddCors(options => 
            {
                options.AddPolicy("Cors", options => 
                {
                    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            }
        );

        var app = builder.Build();
        app.UseCors("Cors");

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}