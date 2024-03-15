// <copyright file="ExpressionTree.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424
using SpreadsheetEngine.Nodes;
#pragma warning disable SA1200
using System.Diagnostics.CodeAnalysis;
using SpreadsheetEngine.Variables;
#pragma warning restore SA1200

namespace SpreadsheetEngine;

/// <summary>
/// ExpressionTree class.
/// </summary>
[SuppressMessage(
    "StyleCop.CSharp.OrderingRules",
    "SA1202:Elements should be ordered by access",
    Justification = "<The order messes with understanding of how methods and elements are connected>")]
[SuppressMessage(
    "StyleCop.CSharp.ReadabilityRules",
    "SA1117:Parameters should be on same line or separate lines",
    Justification = "Parameters that extend offscreen to exorbitant lengths exist, such as this one")]
public class ExpressionTree
{
    private readonly VariableHandler handler;
    private readonly string expression;
    private INode? root;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
    /// Constructor that constructs an Expression Tree from a specific expression.
    /// </summary>
    /// <param name="expression">String from which an expression tree will be made.</param>
    public ExpressionTree(string expression) // (Node root) made it so testing above is easier
    {
        this.handler = new VariableHandler();
        this.root = null;
        this.expression = expression;
        this.Parse();
    }

    /// <summary>
    /// Puts together the aspects of parsing a line and putting the pieces from that line into a tree.
    /// </summary>
    private void Parse()
    {
        var parser = new Parser(this.handler);

        // Old Parser usage
        // this.root = parser.ParseExpression(this.expression);

        // New Parser usage (with parentheses)
        this.root = parser.ParseWithShuntingYard(this.expression);
    }

    /// <summary>
    /// Sets a variable variableName's value to variableValue.
    /// </summary>
    /// <param name="variableName">string.</param>
    /// <param name="variableValue">double.</param>
    public void SetVariable(string variableName, double variableValue)
    {
        this.handler.SetValue(variableName, variableValue);
    }

    /// <summary>
    /// Gets the value from variableName.
    /// </summary>
    /// <param name="variableName">string.</param>
    /// <returns>double.</returns>
    public double GetVariable(string variableName)
    {
        return this.handler.GetValue(variableName);
    }

    /// <summary>
    /// Returns the root of the tree as a Node.
    /// </summary>
    /// <returns>Node.</returns>
    public INode? GetRoot()
    {
        return this.root;
    }

    /// <summary>
    /// Evaluates the expression from the tree to a double value.
    /// </summary>
    /// <returns>The answer of the evaluated expression as a double
    /// (Default for now is 0.0).</returns>
    public double Evaluate()
    {
        return this.root?.GetValue() ?? 0.0;
    }
}