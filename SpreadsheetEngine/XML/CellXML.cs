// <copyright file="CellXML.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Xml.Serialization;

namespace SpreadsheetEngine.XML;

/// <summary>
/// Cell class for XML-related operations for each Cell.
/// </summary>
[XmlType(TypeName = "Cell")]
public class CellXml
{
    /// <summary>
    /// Gets or sets row property.
    /// </summary>
    [XmlAttribute("Row")]
    public int Row { get; set; }

    /// <summary>
    /// Gets or sets column property.
    /// </summary>
    [XmlAttribute("Column")]
    public int Column { get; set; }

    /// <summary>
    /// Gets or sets text property.
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets bgcolor property.
    /// </summary>
    public uint BgColor { get; set; }

    /// <summary>
    /// Gets or sets text color property.
    /// </summary>
    public uint TextColor { get; set; }
}