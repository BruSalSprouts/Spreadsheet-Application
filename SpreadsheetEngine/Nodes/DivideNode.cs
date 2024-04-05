// <copyright file="DivideNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424
namespace SpreadsheetEngine.Nodes;

/// <summary>
/// Division Node.
/// </summary>
public class DivideNode : BinaryOperatorNode
{
    /// <inheritdoc/>
    public override int Precedence => 2;

    /// <inheritdoc/>
    public override char Symbol => '/';

    /// <summary>
    /// Divides the left-side node by the right-side node.
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
                return left.GetValue() / right.GetValue();
            }
        }

        return base.GetValue();
    }
}