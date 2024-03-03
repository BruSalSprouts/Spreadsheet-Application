// <copyright file="BinOperatorNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine.Tree;

public class BinOperatorNode : Node
{
    protected Node? left;
    protected Node? right;
    private char binOperator;

    public BinOperatorNode(char binOperator)
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
    /// 
    /// </summary>
    /// <returns></returns>
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

        return l + r;
    }
}