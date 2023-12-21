
using Microsoft.EntityFrameworkCore;
using RayaTrade.EF;

namespace RayaTrade
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

            // configration for sql
            builder.ConfigrationDB();

            //configration for Automapper
            builder.ConfigrationAutoMapper();

            
            //configration for UnitOfWorkRepository
            builder.ConfigrationUnitofWork();

            //configration for Cores
            builder.ConfigrationCors();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("AllowAnyOrigin");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}