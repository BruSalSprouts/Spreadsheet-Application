// <copyright file="SubtractNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424
namespace SpreadsheetEngine.Nodes;

/// <summary>
/// Subtraction node.
/// </summary>
public class SubtractNode : BinaryOperatorNode
{
    /// <inheritdoc/>
    public override int Precedence => 1;

    /// <inheritdoc/>
    public override char Symbol => '-';

    /// <summary>
    /// Subtracts the right-hand node from the left-hand node.
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
                return left.GetValue() - right.GetValue();
            }
        }

        return base.GetValue();
    }
}