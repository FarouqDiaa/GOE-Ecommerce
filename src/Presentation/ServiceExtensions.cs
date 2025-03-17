using Application.Abstractions.Services;
using Application.Abstractions.UserUseCases;
using Application.Abstractions.ProductUseCases;
using Application.Abstractions.ProductTranslationUseCases;
using Application.Abstractions.CartManagmentUseCases;
using Application.UseCases.UserUseCases;
using Application.UseCases.ProductUseCases;
using Application.UseCases.ProductTranslationUseCases;
using Application.UseCases.CartManagmentUseCases;
using Application.Services;
using Application.Responses;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Middleware;
using System.Text;

namespace Presentation
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddControllers();
            services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                        .Where(ms => ms.Value.Errors.Count > 0)
                        .ToDictionary(
                            ms => ms.Key,
                            ms => ms.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                        );
                    var errorResponse = new ErrorResponse
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });

            // AutoMapper Configuration
            services.AddAutoMapper(typeof(ServiceExtensions).Assembly);

            // Repository Registrations
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductTranslationRepository, ProductTranslationRepository>();
            services.AddScoped<ICartRepository, CartRepository>();

            // Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            // Service Registrations
            services.AddSingleton<IJwtService, JwtService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductTranslationService, ProductTranslationService>();
            services.AddScoped<ICartManagmentService, CartManagmentService>();


            // Use Cases
            services.AddScoped<IRegisterUseCase, RegisterUseCase>();
            services.AddScoped<ILogInUseCase, LogInUseCase>();
            services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
            services.AddScoped<IGetUserDetailsUseCase, GetUserDetailsUseCase>();

            services.AddScoped<IUpdateProductUseCase, UpdateProductUseCase>();
            services.AddScoped<IGetProductDetailsUseCase, GetProductDetailsUseCase>();
            services.AddScoped<IRemoveProductUseCase, RemoveProductUseCase>();
            services.AddScoped<IListProductsUseCase, ListProductsUseCase>();
            services.AddScoped<IAddProductUseCase, AddProductUseCase>();

            services.AddScoped<IAddTranslationUseCase, AddTranslationUseCase>();
            services.AddScoped<IGetProductTranslationUseCase, GetProductTranslationUseCase>();

            services.AddScoped<IAddProductToCartUseCase, AddProductToCartUseCase>();
            services.AddScoped<IRemoveProductFromCartUseCase, RemoveProductFromCartUseCase>();
            services.AddScoped<IGetCartDetailsUseCase, GetCartDetailsUseCase>();

        }
    }
}