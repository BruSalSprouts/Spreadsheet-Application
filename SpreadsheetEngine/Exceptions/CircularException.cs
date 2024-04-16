// <copyright file="CircularException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine.Exceptions;

/// <summary>
/// Exception for circular references.
/// </summary>
public class CircularException() : Exception("Circular Exception!")
{
    /// <summary>
    /// Error message.
    /// </summary>
    public const string Error = "#(Circular reference)!";
}