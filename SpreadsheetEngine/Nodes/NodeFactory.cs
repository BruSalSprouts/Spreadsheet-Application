// <copyright file="NodeFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424
using System.Text.RegularExpressions;
using SpreadsheetEngine.Variables;

namespace SpreadsheetEngine.Nodes;

/// <summary>
/// The Node factory class.
/// </summary>
public partial class NodeFactory
{
    // The symbols that will be used in the Expression Tree
    // The order is reverse PEMDAS.
    // IMPORTANT! PUT THE ORDER OF SYMBOLS IN REVERSE PEMDAS OR THE TREE WILL BREAK
    private static readonly char[] Symbols = ['+', '-', '*', '/'];

    /// <summary>
    /// Dictionary that maps each operation to a specific type of OperatorNode.
    /// </summary>
    private readonly Dictionary<char, Type> operationMap = new Dictionary<char, Type>()
    {
        { Symbols[0], typeof(AddNode) },
        { Symbols[1], typeof(SubtractNode) },
        { Symbols[2], typeof(MultiplyNode) },
        { Symbols[3], typeof(DivideNode) },
    };

    /// <summary>
    /// Returns the list of symbols.
    /// </summary>
    /// <returns>list of symbols.</returns>
    public static IEnumerable<char> GetSymbols()
    {
        return Symbols;
    }

    /// <summary>
    /// Factory that returns a node.
    /// </summary>
    /// <param name="expression">string.</param>
    /// <param name="solver">IVariableResolver.</param>
    /// <returns>INode.</returns>
    public INode? Create(string expression, IVariableResolver solver)
    {
        // If expression has nothing in it.
        if (string.IsNullOrEmpty(expression))
        {
            return null;
        }

        // If the expression is one of the operator key characters.
        if (expression?.Length == 1 && this.operationMap.ContainsKey(expression[0]))
        {
            return (INode)Activator.CreateInstance(this.operationMap[expression[0]])!;
        }

        // If the expression is a valid number.
        if (double.TryParse(expression, out var value))
        {
            return new NumberNode(value);
        }

        // Add expression as a VariableNode if a variable is within the regular expression pattern:
        // If the initial character is A-Z (uppercase or lowercase), then if the rest of the characters are
        // alphanumeric
        return expression != null && MyRegex().IsMatch(expression) ? new VariableNode(expression, solver) : null;
    }

    [GeneratedRegex("^[A-Za-z]+[A-Za-z0-9]*$")]
    private static partial Regex MyRegex();
}