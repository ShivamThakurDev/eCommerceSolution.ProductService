using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ProductService.BLL.Mappers;
using ProductService.BLL.Service.IService;
using ProductService.DAL.Validators;


namespace ProductService.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
        {
            //TO DO: Add Business Logic Layer services into the IoC container
            services.AddAutoMapper(typeof(ProductAddRequestToProductMappingProfile).Assembly);

            services.AddValidatorsFromAssemblyContaining<ProductAddRequestValidator>();

            services.AddScoped<IProductService, ProductService.BLL.Service.ProductService>();

            return services;
        }
    }
}
