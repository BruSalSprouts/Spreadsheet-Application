// <copyright file="IBinOperator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine.Operations;

/// <summary>
/// The IBinOperator interface. What we'll be using for future classes.
/// </summary>
public interface IBinOperator
{
    /// <summary>
    /// Does something with lhs and rhs and returns the result.
    /// </summary>
    /// <param name="lhs">left hand side double.</param>
    /// <param name="rhs">right hand side double.</param>
    /// <returns>double.</returns>
    public double Do(double lhs, double rhs);
}