using BlogMaster_Infraestructure.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogMaster_Infraestructure.Persistence {
    public static class DataAccessConfig {
        public static IServiceCollection ConfigurationConnectionString(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<Context>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
