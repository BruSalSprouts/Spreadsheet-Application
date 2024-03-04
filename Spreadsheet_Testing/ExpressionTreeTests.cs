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
    public void TreeBuiltSingleVariableElementTest()
    {
        var tree = new ExpressionTree("Hello");
        var node = tree.GetRoot();
        Assert.IsTrue(node is VariableNode);
    }

    [Test]
    public void TreeBuiltSingleNumberElementTest()
    {
        var tree = new ExpressionTree("987.654321");
        var node = tree.GetRoot();
        Assert.IsTrue(node is NumberNode);
    }

    [Test]
    public void TreeBuiltSimpleExpressionTest()
    {
        var tree = new ExpressionTree("Blah+99");
        var root = tree.GetRoot();
        var node = root as BinOperatorNode;
        Assert.NotNull(node);
        Assert.Multiple(
            () =>
        {
            Assert.That(node?.Left is VariableNode, Is.True);
            Assert.That(node?.Right is NumberNode, Is.True);
        });
    }
    
    [Test]
    public void TreeBuiltSimpleExpressionEvaluationTest()
    {
        var tree = new ExpressionTree("Blah+99");
        tree.SetVariable("Blah", 1);
        Assert.That(tree.Evaluate(), Is.EqualTo(100));
    }

}