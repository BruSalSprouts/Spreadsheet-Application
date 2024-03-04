// <copyright file="Node.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine.Tree;

/// <summary>
/// The base Node class.
/// </summary>
public abstract class Node
{
    /// <summary>
    /// Gets the value associated with the node.
    /// </summary>
    /// <returns>Double associated with the node.</returns>
    public virtual double GetValue()
    {
        return 0.0;
    }
}