// <copyright file="InvalidFieldNameException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine.Exceptions;

public class InvalidFieldNameException(string message) : Exception(message);