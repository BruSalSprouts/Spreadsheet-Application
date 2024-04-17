// <copyright file="App.axaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Spreadsheet_Bruno_SanchezParra.ViewModels;
using Spreadsheet_Bruno_SanchezParra.Views;

namespace Spreadsheet_Bruno_SanchezParra;

/// <summary>
/// Partial class App.
/// </summary>
public class App : Application
{
    /// <summary>
    /// The initializer for the Avalonia Application.
    /// </summary>
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    /// <summary>
    /// Sets up framework initialization.
    /// </summary>
    public override void OnFrameworkInitializationCompleted()
    {
        if (this.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}