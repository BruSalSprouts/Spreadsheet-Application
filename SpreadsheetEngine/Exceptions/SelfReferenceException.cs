// <copyright file="SelfReferenceException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine.Exceptions;

/// <summary>
/// new Exception class for Self references.
/// </summary>
/// <param name="message">string.</param>
public class SelfReferenceException(string message) : Exception(message)
{
    /// <summary>
    /// Error message.
    /// </summary>
    public const string Error = "#(Self Reference)!";
}