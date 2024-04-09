// <copyright file="FileTypeXML.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Avalonia.Platform.Storage;

namespace Spreadsheet_Bruno_SanchezParra.XML;

public class FileTypeXML
{
    public static FilePickerFileType Xml { get; } = new("XML document")
    {
        Patterns = new[] { "*.xml" },
        MimeTypes = new[] { "text/xml" },
    };
}