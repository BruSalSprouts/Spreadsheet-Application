// <copyright file="ParserTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

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
}