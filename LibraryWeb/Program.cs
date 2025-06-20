
using BookService;
using BookService.Data;
using Domain;
using Microsoft.EntityFrameworkCore;

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

            var connString = Environment.GetEnvironmentVariable("PGSQL_CONN");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseNpgsql("Server=127.0.0.1;Port=5432;Database=library;User Id=postgres;Password=1209;"));

            builder.Services.AddScoped<IBookService, MyBookService>();

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
        }
    }
}
