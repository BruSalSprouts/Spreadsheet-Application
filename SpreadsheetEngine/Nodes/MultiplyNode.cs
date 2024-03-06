// <copyright file="MultiplyNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424
namespace SpreadsheetEngine.Nodes;

/// <summary>
/// Multiplication node.
/// </summary>
public class MultiplyNode : BinaryOperatorNode
{
    /// <summary>
    /// Multiplies together the left-side node to the right-side node.
    /// </summary>
    /// <returns>double.</returns>
    public override double GetValue()
    {
        var left = this.Left;
        if (left != null)
        {
            var right = this.Right;
            if (right != null)
            {
                return left.GetValue() * right.GetValue();
            }
        }

        return base.GetValue();
    }
}