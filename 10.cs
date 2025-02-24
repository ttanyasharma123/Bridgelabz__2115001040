using System;
using System.Reflection;
using System.Runtime.CompilerServices;

public interface IGreeting
{
    void SayHello(string name);
}

public class GreetingService : IGreeting
{
    public void SayHello(string name)
    {
        Console.WriteLine($"Hello, {name}!");
    }
}

// Logging Proxy using DispatchProxy
public class LoggingProxy<T> : DispatchProxy
{
    private T _decorated;

    public static T Create(T decorated)
    {
        object proxy = Create<T, LoggingProxy<T>>();
        ((LoggingProxy<T>)proxy)._decorated = decorated;
        return (T)proxy;
    }

    protected override object Invoke(MethodInfo targetMethod, object[] args)
    {
        // Log the method call
        Console.WriteLine($"[LOG] Calling method: {targetMethod.Name}");

        // Execute the actual method
        return targetMethod.Invoke(_decorated, args);
    }
}

class Program
{
    static void Main()
    {
        // Create original service
        IGreeting greetingService = new GreetingService();

        // Wrap it in the proxy
        IGreeting proxy = LoggingProxy<IGreeting>.Create(greetingService);

        // Call method via proxy
        proxy.SayHello("Tanya");
    }
}

