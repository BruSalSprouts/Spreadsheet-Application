// <copyright file="ExpressionTree.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using SpreadsheetEngine.Tree;

namespace SpreadsheetEngine;

/// <summary>
/// ExpressionTree class
/// </summary>
public class ExpressionTree
{
    private Node? root;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
    /// Constructor that constructs an Expression Tree from a specific expression.
    /// </summary>
    /// <param name="expression">String from which an expression tree will be made</param>
    /// <param name="root">Extra parameter for testing.</param>
    public ExpressionTree(string expression, Node? root)
    {
        this.root = root;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="variableName"></param>
    /// <param name="VariableValue"></param>
    public void SetVariable(string variableName, double VariableValue)
    {
        return;
    }

    /// <summary>
    /// Evalutates the expression from the tree to a double value
    /// </summary>
    /// <returns>The answer of the evaluated expression as a double
    /// (Default for now is 0.0).</returns>
    public double Evaluate()
    {
        return this.root?.GetValue() ?? 0.0;
    }
}