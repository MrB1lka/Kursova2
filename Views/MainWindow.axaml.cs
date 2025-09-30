using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using System.IO;
using System.Collections.Generic;



namespace kursova1.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private List<string> images = new();
     private int Index = 0;   
    public void OnClick(object sender, RoutedEventArgs e)
    {
        string folderPath = way.Text;


        if (!Directory.Exists(folderPath))
        {

            return;
        }

        images.Clear();
        StoragePhoto.Children.Clear();


        foreach (var file in Directory.GetFiles(folderPath))
        {
            try
            {
                images.Add(file);
                StoragePhoto.Children.Add(new Image
                {
                    Source = new Bitmap(file),
                    Width = 250,
                    Height = 250
                });
            }
            catch
            {
                continue;
            }
            
            if (images.Count > 0)
            {
                Index = 0;
                ShowPhot();
            }
        }
    }

    public void ShutDown(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    public void ShowPhot()
    {
        if (images.Count == 0) return;

        using var stream = File.OpenRead(images[Index]);
        Phot.Source = new Bitmap(stream);
        
        var fileInfo = new FileInfo(images[Index]);

        FileNameText.Text = $"FileName: {fileInfo.Name}";
        SizeText.Text = $"Size: {fileInfo.Length / 1024} KB"; // розмір у КБ
        CreationDateText.Text = $"Creation Date: {fileInfo.CreationTime}";
        
        using var img = System.Drawing.Image.FromFile(images[Index]);
        ResolutionText.Text = $"Resolution: {img.Width}x{img.Height}";
        FormatText.Text = $"Format: {img.RawFormat}";
    }

    public void Prevision(object sender, RoutedEventArgs e)
    {
        if (images.Count == 0) return;

    Index--;
    if (Index < 0) Index = images.Count - 1;

    ShowPhot();
    }
     public void Next(object sender, RoutedEventArgs e)
    {
        if (images.Count == 0) return;

    Index++;
    if (Index >= images.Count) Index = 0; 

        ShowPhot();
     }
}