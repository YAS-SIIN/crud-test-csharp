using Microsoft.AspNetCore.ResponseCompression;
using Mc2.CrudTest.IoC;
using Mc2.CrudTest.Domain.Interfaces.UnitOfWork;
using Mc2.CrudTest.Presentation.Server;
using Microsoft.OpenApi.Models;
using Mc2.CrudTest.Presentation.Server.Middlewares;
using FluentValidation;
using System.Reflection;
using Mc2.CrudTest.Application; 

namespace Mc2.CrudTest.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        //builder.Services.AddSwaggerGen();

        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();

        builder.Services.AddSwaggerGen(c =>
        {
            c.CustomSchemaIds(type => type.ToString());
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mc2.CrudTest.Presentation.Server", Version = "v1" });
        });

        builder.Services.Register(builder.Configuration);
         
        //builder.Services.AddValidatorsFromAssemblyContaining<OrganisationValidator>(includeInternalTypes: true);
        builder.Services.AddScoped<ExceptionHandlingMiddleware>();
        builder.Services.AddControllersWithViews();
        var app = builder.Build();

        // Initializing new data
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<IUnitOfWork>();
            DataGenerator.SeedData(services);
        }


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();
        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.UseRouting();


        app.MapRazorPages();
        app.MapControllers();
        app.MapFallbackToFile("index.html");

        app.Run();
    }
}