// <copyright file="BinaryOperatorNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424
using System.Data;

namespace SpreadsheetEngine.Nodes;

/// <summary>
/// Abstract class for BinaryOperators to be made with.
/// </summary>
public abstract class BinaryOperatorNode : INode, IComparable<BinaryOperatorNode>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BinaryOperatorNode"/> class.
    /// </summary>
    protected BinaryOperatorNode()
    {
        this.Left = null;
        this.Right = null;
    }

    /// <summary>
    /// Gets or sets pointer to left node.
    /// </summary>
    public INode? Left { get; set; }

    /// <summary>
    /// Gets or sets pointer to right node.
    /// </summary>
    public INode? Right { get; set; }

    /// <summary>
    /// Gets precedence of operation.
    /// </summary>
    public abstract int Precedence { get; }

    /// <summary>
    /// Gets symbol of operation.
    /// </summary>
    public abstract char Symbol { get; }

    /// <summary>
    /// GetValue method that won't be used but is needed for INode to be inherited.
    /// </summary>
    /// <returns>nothing.</returns>
    /// <exception cref="EvaluateException">Fallback mechanism.</exception>
    public virtual double GetValue()
    {
        throw new EvaluateException("Left or right value is missing.");
    }

    /// <summary>
    /// Compares BinaryOperatorNodes.
    /// </summary>
    /// <param name="other">BinaryOperatorNode.</param>
    /// <returns>int.</returns>
    public int CompareTo(BinaryOperatorNode? other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (ReferenceEquals(null, other))
        {
            return 1;
        }

        var precedenceComparison = this.Precedence.CompareTo(other.Precedence);
        if (precedenceComparison != 0)
        {
            return precedenceComparison;
        }

        return this.Symbol.CompareTo(other.Symbol);
    }
}