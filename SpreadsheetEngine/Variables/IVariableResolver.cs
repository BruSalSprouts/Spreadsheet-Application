// <copyright file="IVariableResolver.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine.Variables;

/// <summary>
/// Interface for VariableResolver.
/// </summary>
public interface IVariableResolver
{
    /// <summary>
    /// Resolves the value.
    /// </summary>
    /// <param name="varName">String.</param>
    /// <returns>double.</returns>
    public double GetValue(string varName);
}