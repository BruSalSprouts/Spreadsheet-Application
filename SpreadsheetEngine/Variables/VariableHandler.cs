// <copyright file="VariableHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424
namespace SpreadsheetEngine.Variables;

/// <summary>
/// Class VariableHandler, for variable handling.
/// </summary>
public class VariableHandler : IVariableResolver
{
    private readonly Dictionary<string, double> store; // A Dictionary for easier handling

    /// <summary>
    /// Initializes a new instance of the <see cref="VariableHandler"/> class.
    /// </summary>
    public VariableHandler()
    {
        this.store = new Dictionary<string, double>();
    }

    /// <summary>
    /// Gets the value from a variable varName.
    /// </summary>
    /// <param name="varName">string.</param>
    /// <returns>double.</returns>
    public double GetValue(string varName)
    {
        return this.store[varName];
    }

    /// <summary>
    /// Stores a value to a variable varName's value.
    /// </summary>
    /// <param name="varName">string.</param>
    /// <param name="value">double.</param>
    public void AddVariable(string varName, double value)
    {
        this.store[varName] = value;
    }

    /// <summary>
    /// Empties the stored variables.
    /// </summary>
    public void Clear()
    {
        this.store.Clear();
    }
}