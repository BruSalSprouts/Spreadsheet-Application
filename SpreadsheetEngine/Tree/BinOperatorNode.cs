// <copyright file="BinOperatorNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using SpreadsheetEngine.Operations;

namespace SpreadsheetEngine.Tree;

/// <summary>
/// BinOperatorNode class
/// </summary>
public class BinOperatorNode : Node
{
    private Node? left;
    private Node? right;
    private readonly IBinOperator binOperator;

    /// <summary>
    /// Initializes a new instance of the <see cref="BinOperatorNode"/> class.
    /// </summary>
    /// <param name="binOperator">Receives an operator <see cref="IBinOperator"/>.</param>
    public BinOperatorNode(IBinOperator binOperator)
    {
        this.binOperator = binOperator;
        this.left = null;
        this.right = null;
    }

    /// <summary>
    /// Gets or sets left Node Property.
    /// </summary>
    public Node? Left
    {
        get => this.left;
        set => this.left = value;
    }

    /// <summary>
    /// Gets or sets right Node Property.
    /// </summary>
    public Node? Right
    {
        get => this.right;
        set => this.right = value;
    }

    /// <summary>
    /// Performs the operation in the node
    /// </summary>
    /// <returns>double.</returns>
    public override double GetValue()
    {
        double l = 0;
        double r = 0;
        if (this.Left != null)
        {
            l = this.Left.GetValue();
        }

        if (this.Right != null)
        {
             r = this.Right.GetValue();
        }

        return this.binOperator.Do(l, r);
    }
}