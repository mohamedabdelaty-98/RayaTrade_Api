using Microsoft.EntityFrameworkCore;
using RayaTrade.Core;
using RayaTrade.Core.AutoMapper;
using RayaTrade.Core.Interfaces;
using RayaTrade.EF;
using RayaTrade.EF.Repositories;

namespace RayaTrade
{
    public static class ConfigrationServices
    {
        public static WebApplicationBuilder ConfigrationDB(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<Context>(option =>
            {
                option.UseLazyLoadingProxies().
                UseSqlServer(builder.Configuration.GetConnectionString("SQL"),
                b => b.MigrationsAssembly(typeof(Context).Assembly.FullName));
            });
            return builder;
        }

        public static WebApplicationBuilder ConfigrationAutoMapper(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            return builder;
        }
        public static WebApplicationBuilder ConfigrationUnitofWork(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            return builder;
        }
        public static WebApplicationBuilder ConfigrationCors(this  WebApplicationBuilder builder)
        {
            builder.Services.AddCors(option =>
              option.AddPolicy("AllowAnyOrigin", builder =>
              builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
          ));
            return builder;
        }
    }
}
