namespace SmartPOS.Application;

using System.Reflection;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SmartPOS.Application.Common.Exceptions;
using SmartPOS.Application.CQRS.Behaviors;

/// <summary>
/// Extension methods that register the application layer services with the dependency injection container.
/// </summary>
public static class DependencyInjection
{
    /// <summary>Registers MediatR, FluentValidation validators, AutoMapper profiles and the exception handler with the service collection.</summary>
    /// <param name="services">The service collection to configure.</param>
    /// <param name="assembly">The assembly to scan for handlers, validators and profiles. Defaults to the calling assembly when <see langword="null" />.</param>
    /// <returns>The configured service collection.</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services, Assembly? assembly = null)
    {
        var applicationAssembly = assembly ?? Assembly.GetExecutingAssembly();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(applicationAssembly);
            cfg.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
        });

        services.AddValidatorsFromAssembly(applicationAssembly);
        services.AddAutoMapper(applicationAssembly);
        services.AddSingleton<IExceptionHandler, ExceptionHandler>();

        return services;
    }
}
