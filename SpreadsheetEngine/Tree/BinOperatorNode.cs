// <copyright file="BinOperatorNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using SpreadsheetEngine.Operations;

namespace SpreadsheetEngine.Tree;

/// <summary>
/// BinOperatorNode class.
/// </summary>
public class BinOperatorNode : Node
{
    private readonly IBinOperator binOperator;
    private Node? left;
    private Node? right;

    /// <summary>
    /// Initializes a new instance of the <see cref="BinOperatorNode"/> class.
    /// </summary>
    /// <param name="binOperator">Receives an operator.<see cref="IBinOperator"/>.</param>
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
    /// Performs the operation in the node.
    /// </summary>
    /// <returns>double.</returns>
    public override double GetValue()
    {
        double l = 0;
        double r = 0;
        if (this.Left != null)
        { // Get the left leaf node's value
            l = this.Left.GetValue();
        }

        if (this.Right != null)
        { // Get the right leaf node's value.
             r = this.Right.GetValue();
        }

        // Do some operation with l and r. In the case that l or r are missing, it'll then be doing something with 0
        return this.binOperator.Do(l, r);
    }
}