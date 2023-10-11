using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        Dictionary<Type, Type> Bindings = new Dictionary<Type, Type>();

        public void Bind(Type interfaceType, Type implementationType)
        {
            if (interfaceType == null) throw new ArgumentNullException("interfaceType cannot be null");
            if (implementationType == null) throw new ArgumentNullException("implementationType cannot be null");

            if (!interfaceType.IsAssignableFrom(implementationType)) 
            {
                throw new ArgumentException("implemenationType does not implement interfaceType");
            }

            if(!Bindings.TryAdd(interfaceType, implementationType)) 
            {
                throw new ArgumentException($"There is already a binding for {interfaceType.Name}.  Add failed.");
            }
        }
        
        public T Get<T>()
        {
            if(!Bindings.TryGetValue(typeof(T), out Type implType))
            {
                throw new ArgumentException($"Container does not have a valid binding entry for {typeof(T).Name}");
            }

            var anInstance = Activator.CreateInstance(implType);
            return (T)anInstance;
        }
    }
}