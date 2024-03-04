// <copyright file="ExpressionTree.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1200
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using SpreadsheetEngine.Operations;
using SpreadsheetEngine.Tree;
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
    private Node? root;

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
        var parser = new Parser();
        var words = parser.Parse(this.expression);
        List<Node> nodes = this.ToNodeList(words);
        this.BuildTree(nodes);
    }

    /// <summary>
    /// Takes in a list of strings and makes a list of nodes out of them.
    /// </summary>
    /// <param name="pieces">List of Strings.</param>
    /// <returns>List of Nodes.</returns>
    private List<Node> ToNodeList(List<string> pieces)
    {
        var nodes = new List<Node>();
        foreach (var piece in pieces)
        {
            if (double.TryParse(piece, out var val))
            { // Add Number Node
                nodes.Add(new NumberNode(val));
            }
            else
            {
                if (char.IsLetter(piece[0]))
                { // Add Variable Node
                    nodes.Add(new VariableNode(piece, this.handler));
                }
                else
                { // Add Operator Node
                    var binOperator = BinOperatorClassifer.Classify(piece);
                    nodes.Add(new BinOperatorNode(binOperator));
                }
            }
        }

        return nodes;
    }

    /// <summary>
    /// Takes the list of Nodes and makes a tree out of it.
    /// </summary>
    /// <param name="nodes">List of nodes (get from ToNodeList).</param>
    /// <exception cref="ValidationException">Error handling in case a node is where it shouldn't be.</exception>
    private void BuildTree(List<Node> nodes)
    {
        foreach (var current in nodes)
        {
            switch (this.root)
            {
                case null:
                    this.root = current;
                    break;

                // If the root is a Leaf Node
                case ILeafNode:
                {// if the left branch of the root doesn't exist
                    if (current is not BinOperatorNode cur)
                    {
                        throw new ValidationException("Invalid Expression");
                    }

                    cur.Left = this.root;
                    this.root = cur;
                    break;
                }

                // If the root is a BinOperatorNode
                default:
                {
                    var opRoot = this.root as BinOperatorNode;

                    // If the right branch of the root doesn't exist
                    if (opRoot?.Right == null)
                    {
                        if (opRoot != null)
                        {
                            opRoot.Right = current;
                        }
                    }
                    else
                    {// Time to make the current node the root
                        if (current is not BinOperatorNode cur)
                        {
                            throw new ValidationException("Invalid Expression");
                        }

                        cur.Left = this.root;
                        this.root = cur;
                    }

                    break;
                }
            }
        }
    }

    /// <summary>
    /// Sets a variable variableName's value to variableValue.
    /// </summary>
    /// <param name="variableName">string.</param>
    /// <param name="variableValue">double.</param>
    public void SetVariable(string variableName, double variableValue)
    {
        this.handler.AddVariable(variableName, variableValue);
    }

    /// <summary>
    /// Returns the root of the tree as a Node.
    /// </summary>
    /// <returns>Node.</returns>
    public Node? GetRoot()
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