using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarTedSystem.BLL;
using StarTedSystem.DAL;

namespace StarTedSystem
{
    public static class StarTedExtensions
    {
        /// <summary>
        /// Register dependencies for the backend services.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="options">The DbContext options.</param>
        public static void StarTedDependencies(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<StarTedContext>(options);

            services.AddTransient<ClubServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<StarTedContext>();
                return new ClubServices(context!);
            });

            services.AddTransient<EmployeeServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<StarTedContext>();
                return new EmployeeServices(context!);
            });
        }
    }
}
