// <copyright file="InvalidFieldNameException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine.Exceptions;

/// <summary>
/// new Exception class for invalid cell names.
/// </summary>
/// <param name="message">string.</param>
public class InvalidFieldNameException(string message) : Exception(message)
{
    /// <summary>
    /// Error message.
    /// </summary>
    public const string Error = "#(Invalid Reference)!";
}