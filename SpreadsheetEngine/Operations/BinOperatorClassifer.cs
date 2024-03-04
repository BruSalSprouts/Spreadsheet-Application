// <copyright file="BinOperatorClassifer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine.Operations;

/// <summary>
/// The BinOperatorClassifier class. Ultimate purpose is to make a string into an Operator type of object.
/// </summary>
public class BinOperatorClassifer
{
    /// <summary>
    /// Takes a string and returns an IBinOperator object.
    /// </summary>
    /// <param name="newOperator">string.</param>
    /// <returns>IBinOperator.</returns>
    public static IBinOperator Classify(string newOperator)
    {
        // We use a switch for now until this can be made better to support more operators.
        return newOperator[0] switch
        {
            '+' => new AddOperator(),
            '-' => new SubtractOperator(),
            '*' => new MultiplyOperator(),
            '/' => new DivideOperator(),
            _ => throw new FormatException("Unsupported Operator")
        };
    }
}