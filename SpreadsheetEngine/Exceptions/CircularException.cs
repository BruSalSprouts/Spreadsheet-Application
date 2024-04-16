// <copyright file="CircularException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine.Exceptions;

/// <summary>
/// Exception for circular references.
/// </summary>
/// <param name="message">string.</param>
public class CircularException(string message) : Exception(message)
{
    /// <summary>
    /// Error message.
    /// </summary>
    public const string Error = "#(Circular reference)!";
}