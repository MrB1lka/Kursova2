using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Drawing;
using Avalonia.Media.Imaging;
using System.IO;

namespace kursova1.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void OnClick(object sender, RoutedEventArgs e)
    {
        string folderPath = way.Text;

        // Перевірка чи існує папка
        if (!Directory.Exists(folderPath))
        {
            // Можна просто повернутись
            return;
        }

        // Очищаємо попередні картинки
        StoragePhoto.Children.Clear();

        // Завантажуємо всі файли з папки
        foreach (var file in Directory.GetFiles(folderPath))
        {
            try
            {
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
        }
    }

    public void ShutDown(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    public void Prevision(object sender, RoutedEventArgs e)
    {

    }
     public void Next(object sender, RoutedEventArgs e)
    {

     }
}