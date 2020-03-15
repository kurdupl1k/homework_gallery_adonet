using System;
using System.Windows;
using System.Windows.Input;
using Project.Data.Models;
using Project.Data.Services;

namespace Project
{
  public partial class LoginWindow : Window
  {
    private UserService user_service;
    public static User current_user;

    public LoginWindow()
    {
      InitializeComponent();
      user_service = new UserService();
    }

    private void Enter_Click(object sender, RoutedEventArgs e)
    {
      Func<User, bool> lambda = x => x.Login == txtbx_login.Text &&
        x.Password == psswrd_password.Password;

      if (user_service.Exists(lambda))
      {
        current_user = user_service.Find(lambda);
        MainWindow main_window = new MainWindow();
      }
      else MessageBox.Show("Login or password is incorrect!",
        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }

    private void Register_Click(object sender, MouseButtonEventArgs e)
    {
      RegisterWindow register_window = new RegisterWindow();
      register_window.Show();

      Close();
    }
  }
}