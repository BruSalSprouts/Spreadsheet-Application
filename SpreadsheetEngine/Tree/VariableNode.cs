// <copyright file="VariableNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using SpreadsheetEngine.Variables;

namespace SpreadsheetEngine.Tree;

/// <summary>
/// The VariableNode class. It represents a variable
/// </summary>
public class VariableNode : Node
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
    /// Gets the value of the variable.
    /// </summary>
    /// <returns>double.</returns>
    public override double GetValue()
    {
        return this.resolver.GetValue(this.varName);
    }
}