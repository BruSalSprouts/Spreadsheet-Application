// <copyright file="ExponentNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine.Nodes;

/// <summary>
/// ExponentNode class. 
/// </summary>
public class ExponentNode : BinaryOperatorNode
{
    /// <summary>
    /// Returns the value left to the power of the value of right.
    /// </summary>
    /// <returns>double.</returns>
    public override double GetValue()
    {
        var left = this.Left;
        if (left == null)
        {
            return base.GetValue();
        }

        var right = this.Right;
        if (right != null)
        {
            return Math.Pow(left.GetValue(), right.GetValue());
        }

        return base.GetValue();
    }
}