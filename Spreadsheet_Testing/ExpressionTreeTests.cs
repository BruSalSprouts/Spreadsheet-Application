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

    /// <summary>
    /// Tests whether an expression tree can evaluate an expression that contains parentheses
    /// with proper Order of Operations.
    /// </summary>
    [Test]
    public void TreeBuiltWithParentheses()
    {
        var tree = new ExpressionTree("(1+2)*(5-2)");
        Assert.That(tree.Evaluate(), Is.EqualTo((1 + 2) * (5 - 2)));
    }

    /// <summary>
    /// Tests whether an expression tree that is "built" with invalid expression (wrong number of parentheses)
    /// returns a null tree.
    /// </summary>
    [Test]
    public void TreeBuiltWithInvalidParenthesesExpression()
    {
        var tree = new ExpressionTree("1+2)*(5-2)");
        Assert.Multiple(
            () =>
        {
            Assert.That(tree.GetRoot(), Is.Null);
            Assert.That(tree.Evaluate(), Is.EqualTo(0.0));
        });
    }

    /// <summary>
    /// Tests whether a tree that contains an invalid expression (Operators are out of order)
    /// returns a null tree.
    /// </summary>
    [Test]
    public void TreeBuiltWithInvaidExpression()
    {
        var tree = new ExpressionTree("5/*4");
        Assert.Multiple(
            () =>
            {
                Assert.That(tree.GetRoot(), Is.Null);
                Assert.That(tree.Evaluate(), Is.EqualTo(0.0));
            });
    }

    /// <summary>
    /// Tests whether an expression tree can evaluate with Exponents (recently added for fun).
    /// </summary>
    [Test]
    public void EvaluateWithExponent()
    {
        var tree = new ExpressionTree("1 + 2 ^ 3");
        Assert.That(tree.Evaluate(), Is.EqualTo(1 + Math.Pow(2, 3)));
    }

    /// <summary>
    /// Tests whether an expression tree's variables A and B are set to 0 automatically, so when
    /// C's value is set, the expression returns a proper answer. (Should be 0, since anything
    /// times 0 is 0).
    /// </summary>
    [Test]
    public void EvaluateWithVariables()
    {
        var tree = new ExpressionTree("A+B*C");
        tree.SetVariable("C", 5342);
        Assert.That(tree.Evaluate(), Is.EqualTo(0));
    }

    /// <summary>
    /// Tests whether an expression tree's variable nodes' values remain after evaluating the tree.
    /// </summary>
    [Test]
    public void VariablesDontResetAfterEvaluation()
    {
        var tree = new ExpressionTree("A+B");
        tree.SetVariable("A", 4);
        tree.SetVariable("B", 5);
        Assert.That(tree.Evaluate(), Is.EqualTo(9));
        Assert.That(tree.GetVariable("A"), Is.EqualTo(4));
        Assert.That(tree.GetVariable("B"), Is.EqualTo(5));
    }
}