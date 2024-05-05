using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using trilha_net;
using trilha_net.Infra.Data.Context;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddServices();
        builder.Services.AddRepositories();        

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(c =>
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Trilha .Net DIO",
                Version = "v1",
                Description = $"build:{DateTime.UtcNow.AddHours(-3):yy.MM.dd.HHmm}",
                Contact = new OpenApiContact() { Name = "Trilha .Net", Email = "00raoni@gmail.com" },
                License = new OpenApiLicense() { Name = "Trilha .Net" }

            });
        });

        string sqlConnKey = "Connections:ConnectionString";
        string? sqlConn = builder.Configuration.GetSection(sqlConnKey).Value;

        builder.Services.AddDbContext<ProjetoContext>(options =>
            options.UseSqlServer(sqlConn, (opts) =>
            {
                opts.EnableRetryOnFailure();
                opts.CommandTimeout(300);
            }));

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseCors(options =>
                       options.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Run();
    }
}