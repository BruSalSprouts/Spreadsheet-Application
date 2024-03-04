// <copyright file="NumberNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine.Tree;

/// <summary>
/// The NumberNode class. It represents a constant numerical value.
/// </summary>
/// <param name="value">double.</param>
public class NumberNode(double value) : INode, ILeafNode
{
    /// <summary>
    /// Gets the value of the Node.
    /// </summary>
    /// <returns>Double.</returns>
    public double GetValue()
    {
        return value;
    }
}