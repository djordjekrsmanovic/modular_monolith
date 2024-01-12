﻿using System.Reflection;

namespace Booking.BuildingBlocks.Infrastructure.Extensions
{
    internal static class InstanceFactory
    {

        internal static IEnumerable<T> CreateFromAssemblies<T>(params Assembly[] assemblies) =>
            assemblies
                .SelectMany(assembly => assembly.DefinedTypes)
                .Where(IsAssignableToType<T>)
                .Select(Activator.CreateInstance)
                .Cast<T>();

        private static bool IsAssignableToType<T>(TypeInfo typeInfo) =>
            typeof(T).IsAssignableFrom(typeInfo) && !typeInfo.IsInterface && !typeInfo.IsAbstract;
    }
}
