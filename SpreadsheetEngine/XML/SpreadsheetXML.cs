// <copyright file="SpreadsheetXML.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Xml.Serialization;

namespace SpreadsheetEngine.XML;

/// <summary>
/// Class that represents what will be saved in an XML file.
/// </summary>
[XmlRoot("Spreadsheet")]
public class SpreadsheetXml : List<RowXml>
{
}