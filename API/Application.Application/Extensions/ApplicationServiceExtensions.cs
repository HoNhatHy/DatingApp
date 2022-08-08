using API.Application.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Application.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices
            (this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}
