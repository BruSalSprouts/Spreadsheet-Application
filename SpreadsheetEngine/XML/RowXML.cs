// <copyright file="RowXML.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Xml.Serialization;

namespace SpreadsheetEngine.XML;

/// <summary>
/// Class for Rows of Cells in XML.
/// </summary>
[XmlType(TypeName = "Row")]
public class RowXml : List<CellXml>
{
}