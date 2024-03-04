// <copyright file="Node.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine.Tree;

/// <summary>
/// The base Node interface.
/// </summary>
public interface INode
{
    /// <summary>
    /// Gets the value associated with the node.
    /// </summary>
    /// <returns>Double associated with the node.</returns>
    public double GetValue();
}