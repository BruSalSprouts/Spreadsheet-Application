﻿using System;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using ReactiveUI;
using System.ComponentModel;
using System.Net.Mime;
using FileLoaderSaver.Models;
namespace FileLoaderSaver.ViewModels;

public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged = delegate { };
    
    private string _textContent;
    private static string _basePath = "C:\\Users\\bruno\\RiderProjects\\cpts321-hws\\FileLoaderSaver\\TextFiles\\";
    #pragma warning disable CA1822 // Mark members as static
    public string Greeting => "Welcome to Avalonia!";
    #pragma warning restore CA1822 // Mark members as static
    public MainWindowViewModel()
    {
        // Create an interaction between the view model and the view for the file to be loaded:
        AskForFileToLoad = new Interaction<Unit, string?>();
        
        // Similarly to load, there's a need to create an interaction for saving into a file:
        AskForFileSave = new Interaction<Unit, string?>();
    }

    private void _PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        this.RaisePropertyChanged();
    }
    /// <summary>
    /// This is a property that will notify the user interface when changed.
    /// TODO: You need to bind this property in the .axaml file
    /// </summary>
    

    public string TextContent
    {
        get => _textContent;
        set
        {
            this.RaiseAndSetIfChanged(ref _textContent, value);
            PropertyChanged(this, new PropertyChangedEventArgs("TextContent"));
        } 
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
        TextReader textFile = new StreamReader(filePath);
        LoadText(textFile);
        textFile.Close();
    }
    /// <summary>
    /// Takes a System.IO.TextReader object "sr" as a parameter, reads all the text from sr and puts
    /// it in the text box in the interrface
    /// </summary>
    /// <param name="sr"></param>
    public void LoadText(TextReader sr)
    {
        StringBuilder tempStr = new StringBuilder("");
        TextContent = (string) sr.ReadToEnd();
        Console.WriteLine(TextContent);
    }
    /// <summary>
    /// Takes in a relative path and returns an absolute file path within the folder of the current project
    /// This comes from a separate project I made that tests loading and saving, I just changed the absolute path
    /// in newString to the folder TextFiles 
    /// </summary>
    /// <param name="filePathPiece"></param>
    /// <returns></returns>
    public static string FinishFilePath(string filePathPiece)
    {
        //We use string builder that starts with the absolute path of the folder that contains the project
        StringBuilder newString =
            new StringBuilder(_basePath);
        
        newString.Append(filePathPiece); //We add the pathname that's the paramemter
        return newString.ToString(); //Return the completed file path
    }
    /// <summary>
    /// Asks the user for a file to save contents into, gets the absolute path for that file via FinishFilePath(),
    /// and sends it to saveText to finish the job 
    /// </summary>
    public async void SaveToFile()
    {
        // TODO: Implement this method.
        var filePath = await AskForFileSave.Handle(default);
        if (filePath == null)
        {
            return;
        }

        TextWriter textWriter = new StreamWriter(filePath);
        SaveText(textWriter);
        Console.WriteLine($"Saved to {filePath}");
        textWriter.Close();
    }
    /// <summary>
    /// Takes in a TextWriter tw and saves the contents of TextContent into into the file within tw
    /// </summary>
    /// <param name="tw"></param>
    public void SaveText(TextWriter tw )
    {
        tw.Write(TextContent);
    }
    public Interaction<Unit, string?> AskForFileToLoad { get; }
    public Interaction<Unit, string?> AskForFileSave { get; }
    /// <summary>
    /// Broadcasts to listeners with propertyName
    /// </summary>
    /// <param name="propertyName"></param>
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
        
    // Ignore this command, I made this for fun with a friend
    public void OwO()
    {
        TextContent = "uWu";
    }
    /// <summary>
    /// Command that takes makes a fibonacciTextReader object fibonacciNumbers that will add up to 50 times at most,
    /// and sets the results of the text made from fibonacciNumbers to TextContent
    /// </summary>
    public void FibonacciTimeFifty()
    {
        FibonacciTextReader fibonacciNumbers = new FibonacciTextReader(50);
        TextContent = fibonacciNumbers.ReadToEnd();
    }
    /// <summary>
    /// Command that takes makes a fibonacciTextReader object fibonacciNumbers that will add up to 100 times at most,
    /// and sets the results of the text made from fibonacciNumbers to TextContent
    /// </summary>
    public void FibonacciTimeHundred()
    {
        FibonacciTextReader fibonacciNumbers = new FibonacciTextReader(100);
        TextContent = fibonacciNumbers.ReadToEnd();
    }
}