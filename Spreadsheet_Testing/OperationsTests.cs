// <copyright file="OperationsTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1200
using SpreadsheetEngine.Operations;
#pragma warning restore SA1200

namespace Spreadsheet_Testing;

/// <summary>
/// OperationsTests class. Here we test the operations themselves to make
/// sure they work.
/// </summary>
public class OperationsTests
{
    /// <summary>
    /// Tests Setup.
    /// </summary>
    [SetUp]
    public void Setup()
    {
    }

    /// <summary>
    /// Tests the Add Operator.
    /// </summary>
    [Test]
    public void AddTest()
    {
        var add = new AddOperator();
        Assert.That(add.Do(3, 5), Is.EqualTo(8));
    }

    /// <summary>
    /// Tests the Subtract Operator.
    /// </summary>
    [Test]
    public void SubtractTest()
    {
        var subtract = new SubtractOperator();
        Assert.That(subtract.Do(10, 7), Is.EqualTo(3));
    }

    /// <summary>
    /// Tests the Multiply Operator.
    /// </summary>
    [Test]
    public void MultiplyTest()
    {
        var multiply = new MultiplyOperator();
        Assert.That(multiply.Do(4, 3), Is.EqualTo(12));
    }

    /// <summary>
    /// Tests the Divide Operator.
    /// </summary>
    [Test]
    public void DivideTest()
    {
        var divide = new DivideOperator();
        Assert.That(divide.Do(12, 4), Is.EqualTo(3));
    }

    /// <summary>
    /// Tests the Divide Operator when dividing by 0.
    /// </summary>
    [Test]
    public void DivideByZeroTest()
    {
        var divide = new DivideOperator();
        Assert.That(divide.Do(12, 0), Is.EqualTo(double.PositiveInfinity));
    }
}