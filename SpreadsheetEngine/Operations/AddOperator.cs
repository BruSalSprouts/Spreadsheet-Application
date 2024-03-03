// <copyright file="AddOperator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine.Operations;

/// <summary>
/// The AddOperator class. Basically handles Addition Operations.
/// </summary>
public class AddOperator : IBinOperator
{
    /// <summary>
    /// Adds lhs and rhs and returns the result
    /// </summary>
    /// <param name="lhs">left hand side double.</param>
    /// <param name="rhs">right hand side double.</param>
    /// <returns>double.</returns>
    public double Do(double lhs, double rhs)
    {
        return lhs + rhs;
    }
}