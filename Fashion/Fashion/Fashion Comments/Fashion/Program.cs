using Fashion.Models;
using Microsoft.EntityFrameworkCore;

namespace Fashion
{
    public class Program 
    {
        public static void Main(string[] args) // ������� ����� ����� � ����������
        {
            var builder = WebApplication.CreateBuilder(args); // �������� ������� ��� ��������� ����������

            // ���������� �������� CORS ��� ���������� �������� � ����� ��������� ������� � ����������
            builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            // ���������� ������������ ��� ��������� HTTP-��������
            builder.Services.AddControllers();
            // ���������� ������ ��� ����������� �������� ����� API
            builder.Services.AddEndpointsApiExplorer();
            // ���������� ������ ��� ��������� ������������ Swagger
            builder.Services.AddSwaggerGen();

            var app = builder.Build(); // �������� ���������� �� ������ ��������

            // ��������� ��������� ��������� HTTP-�������� � ����������� �� ��������� ����������
            if (app.Environment.IsDevelopment())
            {
                // ��������� Swagger ��� ���������������� API
                app.UseSwagger();
                // ��������� ����������������� ���������� Swagger ��� ��������� � ������������ API.
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