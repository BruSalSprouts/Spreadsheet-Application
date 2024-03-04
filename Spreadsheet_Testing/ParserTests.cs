// <copyright file="ParserTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using SpreadsheetEngine;

namespace Spreadsheet_Testing;

public class ParserTests
{
    private Parser? parser;

    [SetUp]
    public void Setup()
    {
        this.parser = new Parser();
    }

    [Test]
    public void ParseSimpleExpression()
    {
        var actual = this.parser?.Parse("A+B");
        var expected = new List<string>() { "A", "+", "B" };
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void ParseSingleElement()
    {
        var actual = this.parser?.Parse("Hello");
        Assert.That(actual?[0], Is.EqualTo("Hello"));
    }

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

    [Test]
    public void ParseEmpty()
    {
        var actual = this.parser?.Parse(string.Empty);
        List<string> expected = [];
        CollectionAssert.AreEqual(expected, actual);
    }
}