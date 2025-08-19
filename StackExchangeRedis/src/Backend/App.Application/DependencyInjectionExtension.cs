using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using App.Application.Map;
using App.Application.UseCases.Product.GetById;
using App.Application.UseCases.Product.Register;
using App.Application.UseCases.Product.Update;

namespace App.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            AddAutoMapper(services);
            AddUseCases(services);
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddScoped(option => new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper());
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IGetProductByIdUseCase, GetProductByIdUseCase>();
            services.AddScoped<IRegisterProductUseCase, RegisterProductUseCase>();
            services.AddScoped<IUpdateProductUseCase, UpdateProductUseCase>();
        }
    }
}
