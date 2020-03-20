using System;
using System.Windows;
using System.Windows.Input;
using Project.Data.Models;
using Project.Data.Services;

namespace Project
{
  public partial class LoginWindow : Window
  {
    private UserService userService;
    public static User currentUser;

    public LoginWindow()
    {
      InitializeComponent();
      userService = new UserService();
    }

    private void Enter_Click(object sender, RoutedEventArgs e)
    {
      Func<User, bool> lambda = (x => x.Login == txtbx_login.Text &&
        x.Password == psswrd_password.Password);

      if (userService.Exists(lambda))
      {
        currentUser = userService.Find(lambda);
        MainWindow mainWindow = new MainWindow();
      }
      else
      {
        MessageBox.Show("Login or password is incorrect!",
          "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }

    private void Register_Click(object sender, MouseButtonEventArgs e)
    {
      RegisterWindow registerWindow = new RegisterWindow();
      registerWindow.Show();

      Close();
    }
  }
}