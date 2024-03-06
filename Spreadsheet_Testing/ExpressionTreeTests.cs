// <copyright file="ExpressionTreeTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424
using SpreadsheetEngine.Nodes;
#pragma warning disable SA1200
using SpreadsheetEngine;

#pragma warning restore SA1200

namespace Spreadsheet_Testing;

/// <summary>
/// ExpressionTreeTests class. Here's where tests related to the Expression Tree
/// are performed.
/// </summary>
public class ExpressionTreeTests
{
    /// <summary>
    /// The setup for ExpressionTreeTests class.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
    }

    /// <summary>
    /// Tests if a tree with a single variable can be built with the
    /// correct node.
    /// </summary>
    [Test]
    public void TreeBuiltSingleVariableElementTest()
    {
        var tree = new ExpressionTree("Hello");
        var node = tree.GetRoot();
        Assert.That(node is VariableNode, Is.True);
    }

    /// <summary>
    /// Tests weather a tree with a single number can be built with the
    /// correct node.
    /// </summary>
    [Test]
    public void TreeBuiltSingleNumberElementTest()
    {
        var tree = new ExpressionTree("987.654321");
        var node = tree.GetRoot();
        Assert.IsTrue(node is NumberNode);
    }

    /// <summary>
    /// Tests whether a simple expression can be made into an expression tree.
    /// The expression contains a variable, an operator (+), and a number.
    /// </summary>
    [Test]
    public void TreeBuiltSimpleExpressionTest()
    {
        var tree = new ExpressionTree("Blah+99");
        var root = tree.GetRoot();
        var node = root as BinaryOperatorNode;
        Assert.That(node, Is.Not.Null);
        Assert.Multiple(
            () =>
        {
            Assert.That(node?.Left is VariableNode, Is.True);
            Assert.That(node?.Right is NumberNode, Is.True);
        });
    }

    /// <summary>
    /// Tests whether an expression tree that's built can correctly evaluate a
    /// simple expression.
    /// </summary>
    [Test]
    public void TreeBuiltSimpleExpressionEvaluationTest()
    {
        var tree = new ExpressionTree("Blah+99");
        tree.SetVariable("Blah", 1);
        Assert.That(tree.Evaluate(), Is.EqualTo(100));
    }

    /// <summary>
    /// Tests whether an expression tree that's built correctly can evaluate
    /// an expression with 3 variables (and 2 + operands).
    /// </summary>
    [Test]
    public void TreeBuiltThreeVarExpressionEvaluationTest()
    {
        var tree = new ExpressionTree("One+Two+Three");
        tree.SetVariable("One", 1);
        tree.SetVariable("Two", 2);
        tree.SetVariable("Three", 3);
        Assert.That(tree.Evaluate(), Is.EqualTo(6));
    }
}