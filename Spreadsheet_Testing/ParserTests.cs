// <copyright file="ParserTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using SpreadsheetEngine.Nodes;
using SpreadsheetEngine.Variables;
#pragma warning disable SA1200
using SpreadsheetEngine;
#pragma warning restore SA1200

namespace Spreadsheet_Testing;

/// <summary>
/// ParserTests class. Here the tests related to the Parser are done.
/// </summary>
public class ParserTests
{
    private Parser? parser;

    /// <summary>
    /// Setup for ParserTests class.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        this.parser = new Parser();
    }

    /// <summary>
    /// Tests whether a simple expression is correctly parsed.
    /// </summary>
    [Test]
    public void ParseSimpleExpression()
    {
        var actual = this.parser?.Parse("A+B");
        var expected = new List<string>() { "A", "+", "B" };
        CollectionAssert.AreEqual(expected, actual);
    }

    /// <summary>
    /// Tests whether the parser can put a single word into a list.
    /// </summary>
    [Test]
    public void ParseSingleElement()
    {
        var actual = this.parser?.Parse("Hello");
        Assert.That(actual?[0], Is.EqualTo("Hello"));
    }

    /// <summary>
    /// Tests whether a parser can parse a complex expression into a list.
    /// </summary>
    [Test]
    public void ParseFiveVariableExpression()
    {
        var actual = this.parser?.Parse("Never+Gonna-Give*You/Up");
        var expected = new List<string>()
        {
            "Never", "+", "Gonna", "-", "Give", "*", "You", "/", "Up",
        };
        CollectionAssert.AreEqual(expected, actual);
    }

    /// <summary>
    /// Tests whether the parser can parse an empty string.
    /// </summary>
    [Test]
    public void ParseEmpty()
    {
        var actual = this.parser?.Parse(string.Empty);
        List<string> expected = [];
        if (expected == null)
        {
            throw new ArgumentNullException(nameof(expected));
        }

        CollectionAssert.AreEqual(expected, actual);
    }

    /// <summary>
    /// Tests if the root node is a proper addition node
    /// </summary>
    [Test]
    public void ParseAddExpressionTest()
    {
        var actual = this.parser?.ParseExpression("a+b+c", new VariableHandler());
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual, Is.TypeOf(typeof(AddNode)));
    }

    /// <summary>
    /// Tests if the root node is a proper subtraction node
    /// </summary>
    [Test]
    public void ParseSubtractExpressionTest()
    {
        var actual = this.parser?.ParseExpression("a-b-c", new VariableHandler());
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual, Is.TypeOf(typeof(SubtractNode)));
    }

    /// <summary>
    /// Tests if the root node is a proper subtraction node
    /// </summary>
    [Test]
    public void ParseMultiplyExpressionTest()
    {
        var actual = this.parser?.ParseExpression("a*b*c", new VariableHandler());
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual, Is.TypeOf(typeof(MultiplyNode)));
    }

    /// <summary>
    /// Tests if the root node is a proper subtraction node
    /// </summary>
    [Test]
    public void ParseDivideExpressionTest()
    {
        var actual = this.parser?.ParseExpression("a/b/c", new VariableHandler());
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual, Is.TypeOf(typeof(DivideNode)));
    }

    /// <summary>
    /// Tests a complex expression so root node is an addition node while the root's children
    /// are multiplication nodes
    /// </summary>
    [Test]
    public void ParseAddAndMultiplyComplexExpressionTest()
    {
        var actual = this.parser?.ParseExpression("a*c+b*d", new VariableHandler());
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual, Is.TypeOf(typeof(AddNode)));
        var op = actual as BinaryOperatorNode;
        Assert.That(op?.Left, Is.TypeOf(typeof(MultiplyNode)));
        Assert.That(op?.Right, Is.TypeOf(typeof(MultiplyNode)));
    }
}