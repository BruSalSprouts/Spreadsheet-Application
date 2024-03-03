// <copyright file="ExpressionTreeTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using SpreadsheetEngine;
using SpreadsheetEngine.Operations;
using SpreadsheetEngine.Tree;

namespace Spreadsheet_Testing;

public class ExpressionTreeTests
{
    [SetUp]
    public void SetUp()
    {
    }

    [Test]
    public void TestEvaluateWithBasicTree()
    {
        BinOperatorNode root = new BinOperatorNode(new AddOperator());
        root.Left = new BinOperatorNode(new MultiplyOperator());
        ((BinOperatorNode)root.Left).Left = new NumberNode(5.0);
        ((BinOperatorNode)root.Left).Right = new NumberNode(3.0);
        root.Right = new NumberNode(5.0);
        var tree = new ExpressionTree(string.Empty, root);
        Assert.That(tree.Evaluate(), Is.EqualTo(20.0));
    }
}