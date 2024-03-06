// <copyright file="NodeFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Text.RegularExpressions;
using SpreadsheetEngine.Variables;

namespace SpreadsheetEngine.Nodes;

public class NodeFactory
{
    /// <summary>
    /// Dictionary that maps each operation to a specific type of OperatorNode
    /// </summary>
    private readonly Dictionary<char, Type> operationMap = new Dictionary<char, Type>()
    {
        { '+', typeof(AddNode) },
        { '-', typeof(SubtractNode) },
        { '*', typeof(MultiplyNode) },
        { '/', typeof(DivideNode) },
    };

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

        // If a variable is within the regular expression pattern:
        // If the initial character is A-Z (uppercase or lowercase), then if the rest of the characters are
        // alphanumeric
        if (Regex.IsMatch(expression, "^[A-Za-z]+[A-Za-z0-9]*$"))
        {
            return new VariableNode(expression, solver);
        }

        return null;
    }
}