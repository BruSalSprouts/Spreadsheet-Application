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

    /// <inheritdoc/>
    public void SetValue(string varName, double newValue)
    {
        this.store[varName] = newValue;
    }

    /// <inheritdoc/>
    public bool Exists(string varName)
    {
        return this.store.ContainsKey(varName);
    }

    /// <inheritdoc/>
    public IEnumerable<string> GetVariableNames()
    {
        return this.store.Keys;
    }

    /// <summary>
    /// Empties the stored variables.
    /// </summary>
    public void Clear()
    {
        this.store.Clear();
    }
}