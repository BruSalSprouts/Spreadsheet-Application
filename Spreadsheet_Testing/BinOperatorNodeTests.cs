// <copyright file="BinOperatorNodeTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1200
using SpreadsheetEngine.Operations;
using SpreadsheetEngine.Tree;
using SpreadsheetEngine.Variables;
#pragma warning restore SA1200

namespace Spreadsheet_Testing;

/// <summary>
/// BinOperatorNodeTests class.
/// </summary>
public class BinOperatorNodeTests
{
    /// <summary>
    /// Sets up the tests.
    /// </summary>
    [SetUp]
    public void Setup()
    {
    }

    /// <summary>
    /// Tests if an operation can be done.
    /// </summary>
    [Test]
    public void TestBinNodeOperation()
    {
        var node = new BinOperatorNode(new AddOperator())
        {
            Left = new NumberNode(4.0),
            Right = new NumberNode(3.0),
        };
        Assert.That(node.GetValue(), Is.EqualTo(7.0));
    }

    /// <summary>
    /// Tests if an operation can be done when there's no children.
    /// </summary>
    [Test]
    public void TestEmptyBinNode()
    {
        var node = new BinOperatorNode(new SubtractOperator());
        Assert.That(node.GetValue(), Is.EqualTo(0));
    }

    /// <summary>
    /// Tests if an operation can be done only when there's a child on the
    /// left node.
    /// </summary>
    [Test]
    public void TestLeftEmptyBinNode()
    {
        var node = new BinOperatorNode(new DivideOperator())
        {
            Right = new NumberNode(10.0),
        };
        Assert.That(node.GetValue(), Is.EqualTo(0));
    }

    /// <summary>
    /// Tests if an operation can be done only when there's a child on the
    /// right node.
    /// </summary>
    [Test]
    public void TestRightEmptyBinNode()
    {
        var node = new BinOperatorNode(new MultiplyOperator())
        {
            Left = new NumberNode(10.0),
        };
        Assert.That(node.GetValue(), Is.EqualTo(0));
    }

    /// <summary>
    /// Tests that a whole tree can evaluate an expression with 3 numbers
    /// and 2 operators.
    /// </summary>
    [Test]
    public void EvaluateExpressionTest()
    {
        var root = new BinOperatorNode(new AddOperator())
        {
            Left = new BinOperatorNode(new MultiplyOperator()),
        };
        ((BinOperatorNode)root.Left).Left = new NumberNode(5.0);
        ((BinOperatorNode)root.Left).Right = new NumberNode(3.0);
        root.Right = new NumberNode(5.0);
        Assert.That(root.GetValue(), Is.EqualTo(20.0));
    }

    /// <summary>
    /// Tests that an expression with variables can be expressed.
    /// </summary>
    [Test]
    public void EvaluateWithVariablesTest()
    {
        var handler = new VariableHandler();
        handler.AddVariable("left", 10.0);
        handler.AddVariable("right", 5.0);
        var root = new BinOperatorNode(new AddOperator())
        {
            Left = new VariableNode("left", handler),
            Right = new VariableNode("right", handler),
        };
        Assert.That(root.GetValue(), Is.EqualTo(15.0));
    }

    /// <summary>
    /// Tests that an expression with a variable and a number can be calculated.
    /// </summary>
    [Test]
    public void EvaluateWithVariableAndNumberTest()
    {
        var handler = new VariableHandler();
        handler.AddVariable("right", 5.0);
        var root = new BinOperatorNode(new AddOperator())
        {
            Left = new NumberNode(5),
            Right = new VariableNode("right", handler),
        };
        Assert.That(root.GetValue(), Is.EqualTo(10.0));
    }
}