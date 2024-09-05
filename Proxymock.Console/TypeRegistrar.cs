using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace Proxymock.Console;

public class TypeRegistrar(IServiceCollection services) : ITypeRegistrar
{
    public void Register(Type service, Type implementation)
    {
        services.AddTransient(service, implementation);
    }

    public void RegisterInstance(Type service, object implementation)
    {
        services.AddSingleton(service, implementation);
    }

    public void RegisterLazy(Type service, Func<object> factory)
    {
        if (factory is null)
        {
            throw new ArgumentNullException(nameof(factory));
        }
        
        services.AddSingleton(service, provider => factory());
    }

    public ITypeResolver Build()
    {
        return new MyTypeResolver(services.BuildServiceProvider());
    }
    
    private class MyTypeResolver : ITypeResolver
    {
        private readonly IServiceProvider _serviceProvider;

        public MyTypeResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public object? Resolve(Type? type)
        {
            return _serviceProvider.GetService(type!);
        }
    }
}