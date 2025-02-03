using HomeServiceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeServiceApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Get Connection String
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Register DbContext
            builder.Services.AddDbContext<HomeServiceDBContext>(options =>
                options.UseSqlServer(connectionString));

            // Enable CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    policy => policy.WithOrigins("http://localhost:3000") // Replace with your frontend URL
                                    .AllowAnyHeader()
                                    .AllowAnyMethod());
            });

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Use CORS
            app.UseCors("AllowReactApp");

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
