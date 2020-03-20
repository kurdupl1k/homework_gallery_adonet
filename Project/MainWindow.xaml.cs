using System.Windows;
using Microsoft.Win32;
using Project.Data.Models;
using Project.Data.Services;
using Project.Data.ViewModels;

namespace Project
{
  public partial class MainWindow : Window
  {
    private User currentUser;
    private ImageService imageService;

    public MainWindow()
    {
      InitializeComponent();
      imageService = new ImageService();
      currentUser = LoginWindow.currentUser;
    }

    private void dg_photos_Loaded(object sender, RoutedEventArgs e)
    {
      dg_photos.ItemsSource = currentUser.Images;
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
      OpenFileDialog fileDialog = new OpenFileDialog();
      bool? result = fileDialog.ShowDialog();

      if (result != null)
      {
        if (result == true)
        {
          foreach (var elem in fileDialog.FileNames)
          {
            imageService.Add(new ImageDTO()
            {
              Name = elem,
              Path = elem,
            });
          }
        }
      }
    }
  }
}