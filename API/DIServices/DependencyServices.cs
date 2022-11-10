using AzureBlobStorage.Implimentations;
using AzureBlobStorage.Interfaces;
using DAL.Configuration;
using DOMAIN.IConfiguration;
using DTO.Profiles;

namespace API.DIServices
{
    public static class DependencyServices
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFileUpload, FileUpload>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddControllers(options =>
            {
                options.RespectBrowserAcceptHeader = true;
            });
            services.AddCors(options =>
            {
                options.AddPolicy("reportfrontend",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:3000")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                    });
            } );

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }

    }
}
