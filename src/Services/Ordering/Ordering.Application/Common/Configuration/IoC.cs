using FluentValidation;
using MediatR;
using MicroservicesProject.Core.Common.Behaviors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Common.Behaviors;
using Ordering.Infrastructure.Data.Configuration;
using System.Reflection;

namespace Ordering.Application.Common.Configuration
{
    public static class IoC
    {
        public static void AddDependencyInject(this IServiceCollection collection, IConfiguration configuration)
        {
            collection.AddAutoMapper(Assembly.GetExecutingAssembly());

            collection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            collection.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            });

            collection.AddInfrastructureServices(configuration);
        }
    }
}
