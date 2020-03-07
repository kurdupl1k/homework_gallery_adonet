using System.Windows;
using Microsoft.Win32;
using Project.Data.Models;
using Project.Data.Services;

namespace Project
{
  public partial class MainWindow : Window
  {
    private UserService user_service;
    private User current_user;

    public MainWindow()
    {
      InitializeComponent();
      current_user = LoginWindow.current_user;
    }

    private void dg_photos_Loaded(object sender, RoutedEventArgs e)
    {
      dg_photos.ItemsSource = current_user.Images;
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
      OpenFileDialog file_dialog = new OpenFileDialog();
      bool? result = file_dialog.ShowDialog();

      if (result != null)
      {
        if (result == true)
        {

        }
        else
        {

        }
      }
    }
  }
}