
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

// Step 1: Create an [Inject] Attribute
[AttributeUsage(AttributeTargets.Constructor)]
public class InjectAttribute : Attribute { }

// Step 2: Define Interfaces and Implementations
public interface IService
{
    void Serve();
}

public class ServiceA : IService
{
    public void Serve()
    {
        Console.WriteLine("ServiceA is serving.");
    }
}

// Step 3: Define a Client Class That Needs Dependency Injection
public class Client
{
    private readonly IService _service;

    [Inject] // Mark constructor for DI
    public Client(IService service)
    {
        _service = service;
    }

    public void Execute()
    {
        _service.Serve();
    }
}

// Step 4: Create a Simple DI Container
public class SimpleDIContainer
{
    private Dictionary<Type, Type> _registrations = new Dictionary<Type, Type>();

    // Register a service implementation for an interface
    public void Register<TInterface, TImplementation>() where TImplementation : TInterface
    {
        _registrations[typeof(TInterface)] = typeof(TImplementation);
    }

    // Resolve dependencies using Reflection
    public T Resolve<T>()
    {
        return (T)Resolve(typeof(T));
    }

    private object Resolve(Type type)
    {
        // Find constructor marked with [Inject]
        ConstructorInfo constructor = type.GetConstructors()
                                          .FirstOrDefault(c => c.GetCustomAttribute<InjectAttribute>() != null);

        if (constructor == null)
        {
            throw new Exception($"No constructor marked with [Inject] found in {type.Name}");
        }

        // Get constructor parameters
        ParameterInfo[] parameters = constructor.GetParameters();
        
        // Resolve each parameter recursively
        object[] dependencies = parameters.Select(p => Resolve(p.ParameterType)).ToArray();

        // Create and return an instance
        return constructor.Invoke(dependencies);
    }
}

// Step 5: Test the DI Container
class Program
{
    static void Main()
    {
        SimpleDIContainer container = new SimpleDIContainer();

        // Register dependencies
        container.Register<IService, ServiceA>();

        // Resolve Client, injecting IService automatically
        Client client = container.Resolve<Client>();

        // Execute method to check DI functionality
        client.Execute();
    }
}


