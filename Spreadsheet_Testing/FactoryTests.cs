// <copyright file="FactoryTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424
using SpreadsheetEngine.Nodes;
using SpreadsheetEngine.Variables;

namespace Spreadsheet_Testing;

/// <summary>
/// FactoryTests Class. Tests related to the NodeFactory class.
/// </summary>
public class FactoryTests
{
    private readonly VariableHandler solver = new VariableHandler();
    private NodeFactory? factory;

    /// <summary>
    /// Setup.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        this.factory = new NodeFactory();
    }

    /// <summary>
    /// Tests if a node is made and if it's of the proper type NumberNode.
    /// </summary>
    [Test]
    public void NumberNodeTest()
    {
        var node = this.factory?.Create("21.420", this.solver);
        Assert.That(node, Is.Not.Null);
        Assert.That(node, Is.TypeOf(typeof(NumberNode)));
    }

    /// <summary>
    /// Tests if a node is made and if it's of the proper type VariableNode.
    /// </summary>
    [Test]
    public void VariableNodeTest()
    {
        var node = this.factory?.Create("Hello99", this.solver);
        Assert.That(node, Is.Not.Null);
        Assert.That(node, Is.TypeOf(typeof(VariableNode)));
    }

    /// <summary>
    /// Tests if a node is made and if it's of the proper type AddNode.
    /// </summary>
    [Test]
    public void OperatorNodeTest()
    {
        var node = this.factory?.Create("+", this.solver);
        Assert.That(node, Is.Not.Null);
        Assert.That(node, Is.TypeOf(typeof(AddNode)));
    }

    /// <summary>
    /// Tests if factory returns a null for a non-valid simple expression.
    /// </summary>
    [Test]
    public void ExpressionTest()
    {
        var node = this.factory?.Create("Hello+World", this.solver);
        Assert.That(node, Is.Null);
    }
}