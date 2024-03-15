// <copyright file="Parser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424

using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using SpreadsheetEngine.Nodes;
using SpreadsheetEngine.Variables;

namespace SpreadsheetEngine;

/// <summary>
/// The Parser class. The ultimate goal is to parse a string but including delimiters as their own strings.
/// </summary>
public partial class Parser
{
    // private static readonly char[] delimiterChars = ['+', '-', '*', '/']; // Delimiters for expression.
    private readonly NodeFactory factory;

    private readonly IVariableResolver solver;

    /// <summary>
    /// Initializes a new instance of the <see cref="Parser"/> class.
    /// </summary>
    /// <param name="solver">IVariableResolver.</param>
    public Parser(IVariableResolver solver)
    {
        this.factory = new NodeFactory();
        this.solver = solver;
    }

    /// <summary>
    /// This parses an expression into an Expression Tree.
    /// </summary>
    /// <param name="expression">string.</param>
    /// <param name="solver">IVariableResolver.</param>
    /// <returns>INode?.</returns>
    public INode? ParseExpression(string expression)
    {
        var node = this.factory.Create(expression, this.solver);
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
            node = this.factory.Create(symbol.ToString(), this.solver); // Makes the BinaryOperatorNode
            ((BinaryOperatorNode)node).Left = this.ParseExpression(left.Trim()); // Parses the left hand side
            ((BinaryOperatorNode)node).Right = this.ParseExpression(right.Trim()); // Parses the right hand side
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

    /// <summary>
    /// Implementation from https://en.wikipedia.org/wiki/Shunting_yard_algorithm.
    /// </summary>
    /// <param name="line">string.</param>
    /// <returns>List of INode.</returns>
    private List<INode> ShuntingYard(string line)
    {
        return [];
    }

    /// <summary>
    /// Builds a tree from an expression using the ShuntingYard algorithm.
    /// </summary>
    /// <param name="line">string.</param>
    /// <returns>INode.</returns>
    internal INode? ParseWithShuntingYard(string line)
    {
        return null;
    }

    // Regular Expression to tokenize the expression for the ShuntingYard method.
    [GeneratedRegex(@"([*+/\-\^)(])|(([0-9]*[.])?[0-9]+|[a-zA-Z]+[a-zA-Z0-9]*)")]
    private static partial Regex MyRegex();
}