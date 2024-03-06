// <copyright file="AddNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine.Nodes;

/// <summary>
/// Addition Node.
/// </summary>
public class AddNode : BinaryOperatorNode
{
    /// <summary>
    /// Adds the left-side node to the right-side node.
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
                return left.GetValue() + right.GetValue();
            }
        }

        return base.GetValue();
    }
}