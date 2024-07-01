using DotNet8.BlogApiWithResultPattern.Repositories;
using DotNet8.BlogApiWithResultPattern.Services;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.BlogApiWithResultPattern
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

            // Register the Service
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                string connectionString = builder.Configuration.GetConnectionString("DbConnection")!;
                opt.UseSqlServer(connectionString);
            });
            builder.Services.AddScoped<IBlogService, BlogService>();
            builder.Services.AddScoped<BlogRepository>();

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
