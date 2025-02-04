using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductService.DAL.Data;
using ProductService.DAL.Repository;
using ProductService.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //TO DO: Add Data Access Layer services into the IoC container


            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseMySQL(configuration.GetConnectionString("DefaultConnection")!);
            });

            services.AddScoped<IProductsRepository, ProductsRepository>();
            return services;
        }
    }
}
