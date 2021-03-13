using System;

namespace Restrike.GitHubIntegration.Api
{
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class LifetimeAttribute : Attribute
    {
    }

    /// <summary>
    /// Marks a class as "transient" lifetime; that is, a new instance is created for every use.
    /// </summary>
    public class TransientLifetimeAttribute : LifetimeAttribute
    {
    }

    /// <summary>
    /// Marks a class as "scoped" lifetime; that is, a new instance is created for each incoming request.
    /// </summary>
    public class ScopedLifetimeAttribute : LifetimeAttribute
    {
    }

    /// <summary>
    /// Marks a class as "singleton" lifetime; that is, a single instance is created for the lifetime of the application.
    /// </summary>
    public class SingletonLifetimeAttribute : LifetimeAttribute
    {
    }
}
