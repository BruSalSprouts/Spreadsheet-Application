// <copyright file="SpreadsheetCellsTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424

#pragma warning disable CS0168 // Variable is declared but never used
namespace Spreadsheet_Testing;

using System;
using SpreadsheetEngine;

/// <summary>
/// SpreadsheetCellsTests class. Tests the functionality of SpreadsheetCells.
/// </summary>
public class SpreadsheetCellsTests
{
    private Spreadsheet? spreadsheet;
    private Spreadsheet? s2;
    private bool catcherCalled;

    /// <summary>
    /// This is the setup for all the tests in class SpreadSheetCellsTests.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        this.spreadsheet = new Spreadsheet(5, 4);
        this.s2 = new Spreadsheet(4, 4);
        this.catcherCalled = false;
    }

    /// <summary>
    /// Tests to see if the right amount of columns are gotten from ColumnCount method.
    /// </summary>
    [Test]
    public void ColumnTest()
    {
        var actual = this.spreadsheet?.ColumnCount();
        Assert.That(actual, Is.EqualTo(4));
    }

    /// <summary>
    /// Tests to see if the right amount of rows are gotten from RowCount method.
    /// </summary>
    [Test]
    public void RowTest()
    {
        var actual = this.spreadsheet?.RowCount();
        Assert.That(actual, Is.EqualTo(5));
    }

    /// <summary>
    /// Tests to see if a Cell is retrieved and is not null.
    /// </summary>
    [Test]
    public void GetCellTest1()
    {
        var cellActual = this.spreadsheet?[1, 1];
        Assert.That(cellActual, Is.Not.Null);
    }

    /// <summary>
    /// Tests to see if a Cell is retrieved and checks to see if the Text is an empty string as it should be.
    /// </summary>
    [Test]
    public void GetCellTest2()
    {
        var cellActual = this.spreadsheet?[4, 3];
        Assert.That(cellActual, Is.Not.Null);
        if (cellActual != null)
        {
            Assert.That(cellActual.Text, Is.EqualTo(string.Empty));
        }
    }

    /// <summary>
    /// Tests to see if a Cell is retrieved, an event that the Cell and/or Value changes, and if the text
    /// is the right set text or not.
    /// </summary>
    [Test]
    public void GetCellTest3()
    {
        var cellActual = this.spreadsheet?[4, 3];
        if (cellActual == null)
        {
            return;
        }

        cellActual.PropertyChanged += (sender, args) =>
        {
            Assert.That(args.PropertyName is "Value" or "Text", Is.True);
            this.catcherCalled = true;
        };
        cellActual.Text = "test";
        Assert.Multiple(
            () =>
        {
            Assert.That(cellActual.Text, Is.EqualTo("test"));
            Assert.That(this.catcherCalled, Is.True);
        });
    }

    /// <summary>
    /// Test to see if we can properly fire a test event to CellPropertyChanged.
    /// </summary>
    [Test]
    public void EventTest1()
    {
        var o = this.spreadsheet;
        if (o == null)
        {
            return;
        }

        o.CellPropertyChanged += (sender, args) =>
        {
            // Checks to see if sender is of type Cell
            Assert.That(sender is Cell, Is.True);
            var cell = (Cell)sender!;
            Assert.That(cell.Text, Is.EqualTo("test")); // An event fires!
        };
        var cellActual = o[4, 3];
        cellActual.Text = "test";
    }

    /// <summary>
    /// Test to see if Getting a cell that's out of range fails.
    /// </summary>
    [Test]
    public void GetCellTestError1()
    {
        try
        {
            var cellActual = this.spreadsheet?[10, 10];
            Assert.Fail();
        }
        catch (IndexOutOfRangeException e)
        {
            Assert.Pass();
        }
    }

    /// <summary>
    /// Test to see if getting a cell that's out of range (with negative numbers) fails.
    /// </summary>
    [Test]
    public void GetCellTestError2()
    {
        try
        {
            var cellActual = this.spreadsheet?[-1, 10];
            Assert.Fail();
        }
        catch (IndexOutOfRangeException e)
        {
            Assert.Pass();
        }
    }

    /// <summary>
    /// Test to see if Setting cell A2 to A1 works properly.
    /// </summary>
    [Test]
    public void FormulaTest1()
    {
        var o = this.spreadsheet;
        if (o == null)
        {
            return;
        }

        o[0, 0].Text = "hello";
        o[0, 1].Text = "=A1";
        Assert.That(o.GetCell(0, 1).Value, Is.EqualTo("hello"));
    }

    /// <summary>
    /// Test to see if Setting cell B3 to A1 works properly.
    /// </summary>
    [Test]
    public void FormulaTest2()
    {
        var o = this.spreadsheet;
        if (o == null)
        {
            return;
        }

        o[0, 0].Text = "hello";
        o.GetCell(1, 2).Text = "=a1";
        Assert.That(o.GetCell(1, 2).Value, Is.EqualTo("hello"));
    }

    /// <summary>
    /// Test to see if setting a cell to an invalid Cell properly throws an exception.
    /// </summary>
    [Test]
    public void FormulaTest3()
    {
        try
        {
            var o = this.spreadsheet;
            if (o != null)
            {
                o[1, 2].Text = "=aA";
            }

            Assert.Fail();
        }
        catch (FormatException f)
        {
            Assert.Pass();
        }
    }

    /// <summary>
    /// Test to see if setting a cell to an invalid Cell properly throws an exception.
    /// </summary>
    [Test]
    public void FormulaTest4()
    {
        try
        {
            var o = this.spreadsheet;
            if (o != null)
            {
                o[1, 2].Text = "=11";
            }

            Assert.That(o?[1, 2].Value, Is.EqualTo(11.ToString()));
        }
        catch (IndexOutOfRangeException f)
        {
            Assert.Fail();
        }
    }

    /// <summary>
    /// Test to see if setting a cell to an invalid Cell that's out of range properly throws an exception.
    /// </summary>
    [Test]
    public void FormulaTest5()
    {
        try
        {
            var o = this.spreadsheet;
            if (o != null)
            {
                o[1, 2].Text = "=A0";
            }

            Assert.That(o?[1, 2].Value, Is.EqualTo("#ERROR!"));
        }
        catch (IndexOutOfRangeException f)
        {
            Assert.Fail();
        }
    }

    /// <summary>
    /// Tests if a short expression tree with just a number node can be evaluated.
    /// </summary>
    [Test]
    public void ShortFormulaTest()
    {
        var o = this.spreadsheet;
        if (o != null)
        {
            o[1, 2].Text = "=1";
        }

        Assert.That(o?[1, 2].Value, Is.EqualTo(1.ToString()));
    }

    /// <summary>
    /// Tests if a short expression tree with just a variable node without the variable having a value
    /// can be evaluated or not.
    /// </summary>
    [Test]
    public void ShortStringFormulaTest()
    {
        var o = this.spreadsheet;
        if (o != null)
        {
            o[1, 2].Text = "=A";
        }

        Assert.That(o?[1, 2].Value, Is.EqualTo("#ERROR!"));
    }

    /// <summary>
    /// Tests if a formula of variables without proper definitions will return with an error or not.
    /// </summary>
    [Test]
    public void ValidFormulaInvalidTextTest()
    {
        var o = this.spreadsheet;
        if (o != null)
        {
            o[0, 0].Text = "hello";
            o[0, 1].Text = "world";
            o[1, 1].Text = "=A1+B1";
        }

        Assert.That(o?[1, 1].Value, Is.EqualTo("#ERROR!"));
    }

    /// <summary>
    /// Tests whether an expression tree with variables will have errors after setting the variables after
    /// the formula is made.
    /// </summary>
    [Test]
    public void ValidFormulaInvalidTextThenValidTest()
    {
        var o = this.spreadsheet;
        if (o != null)
        {
            o[0, 0].Text = "hello";
            o[0, 1].Text = "world";
            o[1, 1].Text = "=A1+B1";
            o[0, 0].Text = "1";
            o[0, 1].Text = "2";
        }

        Assert.That(o?[1, 1].Value, Is.EqualTo("3"));
    }

    /// <summary>
    /// Test to see if changing the value a cell which another cell's value is assigned to will cause the assigning
    /// cell to also change it's value.
    /// </summary>
    [Test]
    public void FormulaTest6()
    {
        var o = this.spreadsheet;
        if (o == null)
        {
            return;
        }

        o[0, 1].Text = "=A1";
        o[0, 0].Text = "hello";
        Assert.That(o[0, 1].Value, Is.EqualTo("hello"));
    }

    /// <summary>
    /// Test to see changing the text of a cell to Empty will change the cell's value to Empty too.
    /// </summary>
    [Test]
    public void CellToEmptyCellTest()
    {
        var o = this.spreadsheet;
        if (o == null)
        {
            return;
        }

        o[0, 1].Text = "=A1";
        o[0, 1].Text = string.Empty;
        Assert.That(o[0, 1].Value, Is.EqualTo(string.Empty));
    }

    /// <summary>
    /// Test to see changing the value of a cell to Empty will cause another cell who is assigned to the original cell
    /// to change it's value to Empty too.
    /// </summary>
    [Test]
    public void CellToEmptyFormulaTest()
    {
        var o = this.spreadsheet;
        if (o == null)
        {
            return;
        }

        o[0, 0].Text = "hello";
        o[0, 1].Text = "=A1";
        o[0, 0].Text = string.Empty;
        Assert.That(o[0, 1].Value, Is.EqualTo(string.Empty));
    }

    /// <summary>
    /// Tests to see if upon initializing all the cells in a Spreadsheet, they all remain empty.
    /// </summary>
    [Test]
    public void CellsStaySameTest1()
    {
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                var cell = this.s2?[row, col];
                if (cell != null)
                {
                    if (cell.Value != string.Empty)
                    {
                        Assert.Fail();
                    }
                }
            }
        }

        Assert.Pass();
    }

    /// <summary>
    /// Tests to see that after changing the Text and Value of a cell, the other cells' Text remain the same.
    /// </summary>
    [Test]
    public void CellsStaySameTest2()
    {
        var o = this.s2;
        if (o != null)
        {
            o[1, 1].Text = "test";
            for (var row = 0; row < 4; row++)
            {
                for (var col = 0; col < 4; col++)
                {
                    if (row == 1 && col == 1)
                    {
                        continue;
                    }

                    var cell = o?[row, col];
                    if (cell == null)
                    {
                        continue;
                    }

                    if (cell.Text != string.Empty)
                    {
                        Assert.Fail();
                    }
                }
            }
        }

        Assert.Pass();
    }

    /// <summary>
    /// Tests to see if a cell that's assigned to another cell have the same Value.
    /// </summary>
    [Test]
    public void CellValueUpdateTest1()
    {
        var o = this.spreadsheet;
        if (o == null)
        {
            return;
        }

        o[0, 1].Text = "=A1";
        o[0, 0].Text = "hello";
        Assert.That(o[0, 0].Value, Is.EqualTo("hello"));
        Assert.That(o[0, 1].Value, Is.EqualTo("hello"));
    }
}