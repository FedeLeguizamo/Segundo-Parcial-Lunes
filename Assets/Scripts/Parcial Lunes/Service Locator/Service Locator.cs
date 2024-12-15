using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{
    private static readonly Dictionary<Type, object> services = new Dictionary<Type, object>();
    
    public static void RegisterService<T>(T service)
    {
        var type = typeof(T);
        if (!services.ContainsKey(type))
        {
            services[type] = service;
        }
    }
    
    public static T GetService<T>()
    {
        var type = typeof(T);
        if (services.TryGetValue(type, out var service))
        {
            return (T)service;
        }

        throw new Exception("Servicio no registrado.");
    }
}
