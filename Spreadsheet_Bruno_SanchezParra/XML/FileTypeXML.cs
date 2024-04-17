// <copyright file="FileTypeXML.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Avalonia.Platform.Storage;

namespace Spreadsheet_Bruno_SanchezParra.XML;

/// <summary>
/// FileTypeXML class. Mainly so file prompts support .xml file formats.
/// </summary>
public class FileTypeXml
{
    /// <summary>
    /// Gets the File type .xml.
    /// </summary>
    public static FilePickerFileType Xml { get; } = new("XML document")
    {
        Patterns = new[] { "*.xml" },
        MimeTypes = new[] { "text/xml" },
    };
}