using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Infrastructure.Persistence;
using Smraa_AlYaman.Infrastructure.Persistence.DbSettings;
using Smraa_AlYaman.Infrastructure.Persistence.repositries.Availablties;
using Smraa_AlYaman.Infrastructure.Persistence.repositries.Barcdes;
using Smraa_AlYaman.Infrastructure.Persistence.repositries.Branchs;
using Smraa_AlYaman.Infrastructure.Persistence.repositries.Orders;
using Smraa_AlYaman.Infrastructure.Persistence.repositries.Productrepositries;
using Smraa_AlYaman.Infrastructure.Persistence.repositries.Products;
using Smraa_AlYaman.Infrastructure.Persistence.repositries.ReadingRepos;
using Smraa_AlYaman.Infrastructure.Persistence.repositries.Supplayers;

namespace Smraa_AlYaman.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            return services;
        }
        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SmraaAlYamanDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("SmraaAlYamanWriteDbConnection");
                options.UseSqlServer(connectionString);
            });


            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<SmraaAlYamanDbContext>());

            services.AddSingleton<IDbSettings>(new ReadingDbSettings(
                    configuration.GetConnectionString("SmraaAlYamanReadDbConnection"))
            );

            DapperTypeHandlerConfiguration.Register();


            services.AddScoped<IAvailabltyRepository, AvailabltyRepository>();

            services.AddScoped<IBarcodeRepository, BarcodeRepository>();

            services.AddScoped<IBrancheRepository,BrancheRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();

            services.AddScoped<ICatagoryRepository, CatagoryRepository>();
            services.AddScoped<ICountryOfOriginRepository, CountryOfOriginRepository>();
            services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();
            services.AddScoped<IProductGroupRepository, ProductGroupRepository>();
            services.AddScoped<ICustomPriceRepository, CustomPriceRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductSupplayerRepository,ProductSupplayerRepository>();
            services.AddScoped<ISupplayerRepository, SupplayerRepository>();
            services.AddScoped<IProductPriceRepository, ProductPriceRepository>();

            return services;
        }
    }

}
