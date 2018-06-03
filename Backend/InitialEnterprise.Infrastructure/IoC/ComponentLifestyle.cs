namespace InitialEnterprise.Infrastructure.IoC
{
    public enum ComponentLifestyle
    {
        //The lifestyle that caches components during the lifetime of the SimpleInjector.Container
        //instance and guarantees that only a single instance of that component is created
        //for that instance. Since general use is to create a single Container instance
        //for the lifetime of the application / AppDomain, this would mean that only a
        //single instance of that component would exist during the lifetime of the application.
        //In a multi-threaded applications, implementations registered using this lifestyle
        //must be thread-safe.
        //In case the type of a cached instance implements System.IDisposable, the container
        //will ensure its disposal when the container gets disposed.
        Singleton,

        //The lifestyle instance that doesn't cache instances. A new instance of the specified
        //component is created every time the registered service is requested or injected.
        Transient,

        //The lifestyle that caches components according to the lifetime of the container's
        //configured scoped lifestyle.
        //In case the type of a cached instance implements System.IDisposable, the container
        //will ensure its disposal when the active scope gets disposed.
        Scoped

    }
     
}
