// <copyright file="Parser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424
using System.Text;
using SpreadsheetEngine.Nodes;
using SpreadsheetEngine.Variables;

namespace SpreadsheetEngine;

/// <summary>
/// The Parser class. The ultimate goal is to parse a string but including delimiters as their own strings.
/// </summary>
public class Parser
{
    // private static readonly char[] delimiterChars = ['+', '-', '*', '/']; // Delimiters for expression.
    private readonly NodeFactory factory;

    /// <summary>
    /// Initializes a new instance of the <see cref="Parser"/> class.
    /// </summary>
    public Parser()
    {
        this.factory = new NodeFactory();
    }

    /// <summary>
    /// This parses an expression into an Expression Tree.
    /// </summary>
    /// <param name="expression">string.</param>
    /// <param name="solver">IVariableResolver.</param>
    /// <returns>INode?.</returns>
    public INode? ParseExpression(string expression, IVariableResolver solver)
    {
        var node = this.factory.Create(expression, solver);
        if (node != null)
        { // If the expression is empty or invalid
            return node;
        }

        var symbols = NodeFactory.GetSymbols();

        // For each of the operation characters listed in symbol
        foreach (var symbol in symbols)
        {
            var index = expression.LastIndexOf(symbol); // Finds the last occurrence of a symbol
            if (index == -1)
            {
                continue;
            }

            var left = expression[..index]; // Gets the left hand side
            var right = expression[(index + 1)..]; // Gets the right hand side
            node = this.factory.Create(symbol.ToString(), solver); // Makes the BinaryOperatorNode
            ((BinaryOperatorNode)node).Left = this.ParseExpression(left.Trim(), solver); // Parses the left hand side
            ((BinaryOperatorNode)node).Right = this.ParseExpression(right.Trim(), solver); // Parses the right hand side
            return node;
        }

        return node;
    }

    /// <summary>
    /// Takes in a line of text and returns a list of strings that includes the delimiters as their own
    /// strings within the list.
    /// </summary>
    /// <param name="line">string.</param>
    /// <returns>List of strings.</returns>
    public List<string> Parse(string line)
    {
        var pieces = new List<string>();
        var sb = new StringBuilder();
        foreach (var c in line)
        {
            if (NodeFactory.GetSymbols().Contains(c))
            { // If char c is one of the symbols, it adds sb to the list and c itself to the list
                pieces.Add(sb.ToString());
                pieces.Add(c.ToString());
                sb.Clear();
            }
            else
            {
                sb.Append(c);
            }
        }

        if (sb.Length > 0)
        { // In case sb still has something
            pieces.Add(sb.ToString());
        }

        return pieces;
    }
}