
using MyRepoApps.Models;
using MyRepoApps.Models.Extensions;
using MyRepoApps.Repository;
using MyRepoApps.Repository.Interface;

namespace MyRepoApps
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.GetConnectionString("Default");

            // Add services to the container.
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddRepositoryScoped<IMRepository, MReposityRepo, MRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
