﻿// <copyright file="MainWindow.axaml.cs" company="CptS 321 Instructor">
// Copyright (c) CptS 321 Instructor. All rights reserved.
// </copyright>

using TextFileLoaderSaver.ViewModels;

namespace HW3.ViewModels;

using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;

public class MainWindowViewModel : ViewModelBase
{

    public MainWindowViewModel()
    {

        // Create an interaction between the view model and the view for the file to be loaded:
        AskForFileToLoad = new Interaction<Unit, string?>();

        // Similarly to load, there is a need to create an interaction for saving into a file:
        // TODO: Your code goes here.
    }

    /// <summary>
    /// This is a property that will notify the user interface when changed.
    /// TODO: You need to bind this property in the .axaml file
    /// </summary>
    public string FibonacciNumbers
    {
        get => FibonacciNumbers;
        private set => this.RaiseAndSetIfChanged(ref FibonacciNumbers, value);
    }

    /// <summary>
    /// This method will be executed when the user wants to load content from a file.
    /// </summary>
    public async void LoadFromFile()
    {
        // Wait for the user to select the file to load from.
        var filePath = await AskForFileToLoad.Handle(default);
        if (filePath == null) return;

        // If the user selected a file, create the stream reader and load the text.
        var textReader = new StreamReader(filePath);
        LoadText(textReader);
        textReader.Close();
    }

    public async void SaveToFile()
    {
        // TODO: Implement this method.
    }

    public Interaction<Unit, string?> AskForFileToLoad { get; }
    public object Greeting { get; }

    // other code...
}