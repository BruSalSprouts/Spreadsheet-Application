// <copyright file="MainWindow.axaml.cs" company="CptS 321 Instructor">
// Copyright (c) CptS 321 Instructor. All rights reserved.
// </copyright>

using HW3.ViewModels;
using TextFileLoaderSaver.ViewModels;

namespace TextFileLoaderSaver.Views;

using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using TextFileLoaderSaver.ViewModels;
using ReactiveUI;

/// <summary>
/// This class handles all necessary UI events to communicate with the view model and sub windows.
/// </summary>
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();

        this.WhenActivated(d => d(ViewModel!.AskForFileToLoad.RegisterHandler(DoOpenFile)));

        // TODO: add code for saving
    }

    // Use the following version of DoOpenFile if you are using Avalonia 10
    /// <summary>
    /// Opens a dialog to select a file which will be used to load content.
    /// </summary>
    /// <param name="interaction">Defines the Input/Output necessary for this workflow to complete successfully.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    private async Task DoOpenFile(InteractionContext<Unit, string?> interaction)
    {
        var fileDialog = new OpenFileDialog
        {
            AllowMultiple = false,
        };
        var txtFiler = new FileDialogFilter
        {
            Extensions = { "txt" },
        };
        var fileDialogFilters = new List<FileDialogFilter>
        {
            txtFiler,
        };
        fileDialog.Filters = fileDialogFilters;
        var filePath = await fileDialog.ShowAsync(this);
        interaction.SetOutput(filePath is { Length: 1 } ? filePath[0] : null);
    }

    // Use the following version of DoOpenFile if you are using Avalonia 11
    /// <summary>
    /// Opens a dialog to select a file which will be used to load content.
    /// </summary>
    /// <param name="interaction">Defines the Input/Output necessary for this workflow to complete successfully.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    // private async Task DoOpenFile(InteractionContext<Unit, string?> interaction)
    // {
    //     // Get top level from the current control. Alternatively, you can use Window reference instead.
    //     var topLevel = TopLevel.GetTopLevel(this);
    //
    //     // List of filtered types
    //     var fileType = new FilePickerFileType("txt");
    //     var fileTypes = new List<FilePickerFileType>();
    //     fileTypes.Add(fileType);
    //
    //     // Start async operation to open the dialog.
    //     var filePath = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
    //     {
    //         Title = "Open Text File",
    //         AllowMultiple = false,
    //         FileTypeFilter = fileTypes,
    //     });
    //
    //     interaction.SetOutput(filePath.Count == 1 ? filePath[0].Path.AbsolutePath : null);
    // }

    /// <summary>
    /// Opens a dialog to select a file in which content will be saved.
    /// </summary>
    /// <param name="interaction">Defines the Input/Output necessary for this workflow to complete successfully.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    private async Task DoSaveFile(InteractionContext<Unit, string?> interaction)
    {
        // TODO: your code goes here.
    }
}