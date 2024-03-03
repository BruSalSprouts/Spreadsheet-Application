// <copyright file="BinOperatorNodeTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using SpreadsheetEngine.Operations;
using SpreadsheetEngine.Tree;
using SpreadsheetEngine.Variables;

namespace Spreadsheet_Testing;

public class BinOperatorNodeTests
{
    /// <summary>
    /// Sets up the tests
    /// </summary>
    [SetUp]
    public void Setup()
    {
    }

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

    [Test]
    public void TestEmptyBinNode()
    {
        var node = new BinOperatorNode(new SubtractOperator());
        Assert.That(node.GetValue(), Is.EqualTo(0));
    }

    [Test]
    public void TestLeftEmptyBinNode()
    {
        var node = new BinOperatorNode(new DivideOperator())
        {
            Right = new NumberNode(10.0),
        };
        Assert.That(node.GetValue(), Is.EqualTo(0));
    }

    [Test]
    public void TestRightEmptyBinNode()
    {
        var node = new BinOperatorNode(new MultiplyOperator())
        {
            Left = new NumberNode(10.0),
        };
        Assert.That(node.GetValue(), Is.EqualTo(0));
    }

    [Test]
    public void EvaluateExpressionTest()
    {
        BinOperatorNode root = new BinOperatorNode(new AddOperator());
        root.Left = new BinOperatorNode(new MultiplyOperator());
        ((BinOperatorNode)root.Left).Left = new NumberNode(5.0);
        ((BinOperatorNode)root.Left).Right = new NumberNode(3.0);
        root.Right = new NumberNode(5.0);
        Assert.That(root.GetValue(), Is.EqualTo(20.0));
    }

    [Test]
    public void EvaluateWithVariablesTest()
    {
        var handler = new VariableHandler();
        handler.AddVariable("left", 10.0);
        handler.AddVariable("right", 5.0);
        BinOperatorNode root = new BinOperatorNode(new AddOperator());
        root.Left = new VariableNode("left", handler);
        root.Right = new VariableNode("right", handler);
        Assert.That(root.GetValue(), Is.EqualTo(15.0));
    }

    [Test]
    public void EvaluateWithVariableAndNumberTest()
    {
        var handler = new VariableHandler();
        handler.AddVariable("right", 5.0);
        BinOperatorNode root = new BinOperatorNode(new AddOperator());
        root.Left = new NumberNode(5);
        root.Right = new VariableNode("right", handler);
        Assert.That(root.GetValue(), Is.EqualTo(10.0));
    }
}