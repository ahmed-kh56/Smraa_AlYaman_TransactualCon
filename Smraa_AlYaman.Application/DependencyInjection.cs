using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Smraa_AlYaman.Application.Common.Behaviors;

namespace Smraa_AlYaman.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationMarker).Assembly));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssemblyContaining(typeof(ApplicationMarker));


            return services;

        }
    }
}
