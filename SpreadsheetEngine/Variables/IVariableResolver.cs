// <copyright file="IVariableResolver.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424
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

    /// <summary>
    /// Sets newValue to variable varName.
    /// </summary>
    /// <param name="varName">string.</param>
    /// <param name="newValue">double.</param>
    public void SetValue(string varName, double newValue);

    /// <summary>
    /// Checks to see whether variable varName already exists or not.
    /// </summary>
    /// <param name="varName">string.</param>
    /// <returns>bool.</returns>
    public bool Exists(string varName);

    /// <summary>
    /// Returns the list of variable names.
    /// </summary>
    /// <returns>IEnumerable<string/>.</returns>
    public IEnumerable<string> GetVariableNames();
}