// <copyright file="SelfReferenceException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine.Exceptions;

public class SelfReferenceException(string message) : Exception(message);