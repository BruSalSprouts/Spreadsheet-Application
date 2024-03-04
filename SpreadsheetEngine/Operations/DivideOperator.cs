// <copyright file="DivideOperator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine.Operations;

/// <summary>
/// The DivideOperator class. Basically handles Division Operations.
/// </summary>
public class DivideOperator : IBinOperator
{
    /// <summary>
    /// Divides rhs from lhs and returns the result.
    /// Divide by 0 is handled by .NET (Positive infinity!).
    /// </summary>
    /// <param name="lhs">left hand side double.</param>
    /// <param name="rhs">right hand side double.</param>
    /// <returns>double.</returns>
    public double Do(double lhs, double rhs)
    {
        return lhs / rhs;
    }
}