
using Microsoft.EntityFrameworkCore;
using ZooManager.Api.Extensions;
using ZooManager.Api.Services;
using ZooManager.Api.Services.Impl;

namespace ZooManager.Api
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

            // Регистрация всех репозиториев
            builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<ITicketRepository, TicketRepository>();

            // Регистрация контекста EF для взаимодействия с субд MsSql
            builder.Services.AddDbContext<ZooManagetDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ZooManagerConnectionString"));
            });

            var app = builder.Build();

            // Метод расширения. Применить все существующие миграции
            app.ApplyMigrations();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
