// <copyright file="InvalidFieldType.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine.Exceptions;

/// <summary>
/// new Exception class for invalid field types.
/// </summary>
/// <param name="message">string.</param>
public class InvalidFieldType(string message) : Exception(message);