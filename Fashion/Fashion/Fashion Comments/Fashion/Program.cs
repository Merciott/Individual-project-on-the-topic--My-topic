using Fashion.Models;
using Microsoft.EntityFrameworkCore;

namespace Fashion
{
    public class Program 
    {
        public static void Main(string[] args) // Главная точка входа в приложение
        {
            var builder = WebApplication.CreateBuilder(args); // Создание объекта для настройки приложения

            // Добавление политики CORS для разрешения запросов с любых источнико методов и заголовков
            builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            // Добавление контроллеров для обработки HTTP-запросов
            builder.Services.AddControllers();
            // Добавление службы для обнаружения конечных точек API
            builder.Services.AddEndpointsApiExplorer();
            // Добавление службы для генерации документации Swagger
            builder.Services.AddSwaggerGen();

            var app = builder.Build(); // Создание приложения на основе настроек

            // Настройка конвейера обработки HTTP-запросов в зависимости от окружения разработки
            if (app.Environment.IsDevelopment())
            {
                // Включение Swagger для документирования API
                app.UseSwagger();
                // Включение пользовательского интерфейса Swagger для просмотра и тестирования API.
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("MyPolicy");

            app.MapControllers();

            app.Run();
        }
    }
}