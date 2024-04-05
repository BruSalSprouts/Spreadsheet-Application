// <copyright file="InvalidValueException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine.Exceptions;

/// <summary>
/// new Exception class for invalid variable values.
/// </summary>
/// <param name="message">string.</param>
public class InvalidValueException(string message) : Exception(message);
