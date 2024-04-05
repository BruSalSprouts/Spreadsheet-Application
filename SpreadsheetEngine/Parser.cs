// <copyright file="Parser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424

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

    private readonly Dictionary<char, int> operatorOrder;

    /// <summary>
    /// Initializes a new instance of the <see cref="Parser"/> class.
    /// </summary>
    /// <param name="solver">IVariableResolver.</param>
    public Parser(IVariableResolver solver)
    {
        this.factory = new NodeFactory();
        this.solver = solver;
        this.operatorOrder = new Dictionary<char, int>();
        foreach (var op in ReflectiveEnumerator.GetEnumerableOfType<BinaryOperatorNode>())
        {
            this.operatorOrder.Add(op.Symbol, op.Precedence);
        }
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
            if (this.operatorOrder.ContainsKey(c))
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
        var expressionList = new List<INode>();
        var operatorStack = new Stack<string>();

        // Regex for numbers from https://stackoverflow.com/questions/12643009/regular-expression-for-floating-point-numbers.
        var matches = MyRegex().Matches(line);

        foreach (var match in matches)
        {
            var token = match.ToString();
            if (string.IsNullOrEmpty(token))
            {
                continue;
            }

            var node = this.factory.Create(token, this.solver);
            if (node is ILeafNode)
            { // If it's not an operator node
                if (node is VariableNode variableNode)
                {
                    // Initialize new variables to 0.0
                    var name = variableNode.GetName();
                    if (!this.solver.Exists(name))
                    {
                        this.solver.SetValue(name, 0.0);
                    }
                }

                expressionList.Add(node);
            }
            else
            {
                switch (token[0])
                {
                    // Push to stack
                    case '(':
                        operatorStack.Push(token);
                        break;
                    case ')':
                        // While the top operator is (
                        while (operatorStack.Count > 0 && operatorStack.Peek()[0] != '(')
                        {
                            var opNode = this.factory.Create(operatorStack.Pop(), this.solver);
                            if (opNode != null)
                            {
                                expressionList.Add(opNode);
                            }
                        }

                        if (operatorStack.Count < 1)
                        { // Invalid parentheses error handler (returns empty list)
                            return [];
                        }

                        operatorStack.Pop(); // Discards (
                        break;
                    default:
                        if (this.operatorOrder.TryGetValue(token[0], out var precedenceCheck))
                        {
                            // Handle precedence here
                            while (operatorStack.Count > 0 &&
                                   this.operatorOrder.ContainsKey(operatorStack.Peek()[0]) &&
                                   this.operatorOrder[operatorStack.Peek()[0]] >= precedenceCheck)
                            {
                                var opNode = this.factory.Create(operatorStack.Pop(), this.solver);
                                if (opNode != null)
                                {
                                    expressionList.Add(opNode);
                                }
                            }

                            operatorStack.Push(token);
                        }

                        break;
                }
            }
        }

        // Deals with remaining operators
        while (operatorStack.Count > 0)
        {
            var opNode = this.factory.Create(operatorStack.Pop(), this.solver);
            if (opNode != null)
            {
                expressionList.Add(opNode);
            }
        }

        return expressionList;
    }

    /// <summary>
    /// Makes an expression tree from a string using ShuntingYard.
    /// </summary>
    /// <param name="line">string.</param>
    /// <returns>Expression Tree of INodes.</returns>
    internal INode? ParseWithShuntingYard(string line)
    {
        var nodes = this.ShuntingYard(line);
        var nodesStack = new Stack<INode>();
        foreach (var node in nodes)
        {
            if (node is ILeafNode)
            { // Push leaf node to stack
                nodesStack.Push(node);
            }
            else
            { // Get the top two nodes from the stack
                // Invalid expression check
                if (nodesStack.Count < 2)
                {
                    return null;
                }

                var right = nodesStack.Pop();
                var left = nodesStack.Pop();

                // Assign the nodes to a simple binary tree
                ((BinaryOperatorNode)node).Right = right;
                ((BinaryOperatorNode)node).Left = left;

                // Push the operator node to stack
                nodesStack.Push(node);
            }
        }

        // If only one thing is in the stack, we return the successfully made tree. Else we return null (An error)
        return nodesStack.Count == 1 ? nodesStack.Pop() : null;
    }

    [GeneratedRegex(@"([*+/\-\^)(])|(([0-9]*[.])?[0-9]+|[a-zA-Z]+[a-zA-Z0-9]*)")]
    private static partial Regex MyRegex();
}