// <copyright file="ReflectiveEnumerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Reflection;

namespace SpreadsheetEngine;

/// <summary>
/// Got from https://stackoverflow.com/questions/5411694/get-all-inherited-classes-of-an-abstract-class.
/// </summary>
public static class ReflectiveEnumerator
{
    /// <summary>
    /// Enumerates all classes derived from type T.
    /// </summary>
    /// <param name="constructorArgs">Arguments for constructor.</param>
    /// <typeparam name="T">Type.</typeparam>
    /// <returns>List of types.</returns>
    public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs)
        where T : class, IComparable<T>
    {
        List<T> objects = [];
        foreach (var type in
                 Assembly.GetAssembly(typeof(T))
                     ?.GetTypes() // Lambda operation below.
                     .Where(myType => myType is { IsClass: true, IsAbstract: false } && myType.IsSubclassOf(typeof(T)))!)
        {
            objects.Add((T)Activator.CreateInstance(type, constructorArgs)! ?? throw new InvalidOperationException());
        }

        objects.Sort();
        return objects;
    }
}