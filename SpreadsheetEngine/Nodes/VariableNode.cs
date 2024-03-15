// <copyright file="VariableNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424
#pragma warning disable SA1200
using SpreadsheetEngine.Variables;
#pragma warning restore SA1200

namespace SpreadsheetEngine.Nodes;

/// <summary>
/// The VariableNode class. It represents a variable.
/// </summary>
public class VariableNode : INode, ILeafNode
{
    private readonly string varName;
    private readonly IVariableResolver resolver;

    /// <summary>
    /// Initializes a new instance of the <see cref="VariableNode"/> class.
    /// </summary>
    /// <param name="varName">string.</param>
    /// <param name="resolver">IVariableResolver.</param>
    public VariableNode(string varName, IVariableResolver resolver)
    {
        this.varName = varName;
        this.resolver = resolver;
    }

    /// <summary>
    /// Returns the variable name.
    /// </summary>
    /// <returns>string.</returns>
    public string GetName()
    {
        return this.varName;
    }

    /// <summary>
    /// Gets the value of the variable.
    /// </summary>
    /// <returns>double.</returns>
    public double GetValue()
    {
        return this.resolver.GetValue(this.varName);
    }

    /// <summary>
    /// Returns the variable name.
    /// </summary>
    /// <returns>string.</returns>
    public override string ToString()
    {
        return this.varName;
    }
}