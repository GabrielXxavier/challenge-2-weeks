
using BookService;
using BookService.Data;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LibraryWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            DotNetEnv.Env.Load();

            
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseNpgsql("Server=127.0.0.1;Port=5432;Database=library;User Id=postgres;Password=1209;")
                 .EnableSensitiveDataLogging());

            builder.Services.AddScoped<IBookService, MyBookService>();
            builder.Services.AddScoped<ICategoryService, MyCategoryService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Policy", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("Policy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
