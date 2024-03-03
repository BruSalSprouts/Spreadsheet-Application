// <copyright file="NumberNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>


namespace SpreadsheetEngine.Tree;

public class NumberNode(double val) : Node
{
    /// <summary>
    /// Gets the value of the Node.
    /// </summary>
    /// <returns>Double.</returns>
    public override double GetValue()
    {
        return val;
    }
}