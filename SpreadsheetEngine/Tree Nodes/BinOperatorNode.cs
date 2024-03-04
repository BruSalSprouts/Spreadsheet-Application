// <copyright file="BinOperatorNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1200
using SpreadsheetEngine.Operations;
#pragma warning restore SA1200

namespace SpreadsheetEngine.Tree;

/// <summary>
/// BinOperatorNode class.
/// </summary>
public class BinOperatorNode : INode
{
    private readonly IBinOperator binOperator;
    private INode? left;
    private INode? right;

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
    public INode? Left
    {
        get => this.left;
        set => this.left = value;
    }

    /// <summary>
    /// Gets or sets right Node Property.
    /// </summary>
    public INode? Right
    {
        get => this.right;
        set => this.right = value;
    }

    /// <summary>
    /// Performs the operation in the node.
    /// </summary>
    /// <returns>double.</returns>
    public double GetValue()
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