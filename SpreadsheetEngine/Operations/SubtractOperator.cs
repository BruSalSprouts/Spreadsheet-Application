// <copyright file="SubtractOperator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine.Operations;

/// <summary>
/// The SubtractOperator class. Basically handles Subtraction Operations.
/// </summary>
public class SubtractOperator : IBinOperator
{
    /// <summary>
    /// Subtracts rhs from lhs and returns the result
    /// </summary>
    /// <param name="lhs">left hand side double.</param>
    /// <param name="rhs">right hand side double.</param>
    /// <returns>double.</returns>
    public double Do(double lhs, double rhs)
    {
        return lhs - rhs;
    }
}