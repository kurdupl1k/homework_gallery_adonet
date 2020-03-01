﻿using System.Windows;
using System.Windows.Input;
using Project.Data.Services;

namespace Project
{
  public partial class LoginWindow : Window
  {
    private UserService user_service;

    private MainWindow main_window;
    private RegisterWindow register_window;

    public LoginWindow()
    {
      InitializeComponent();
      user_service = new UserService();
    }

    private void Enter_Click(object sender, RoutedEventArgs e)
    {
      if (user_service.Exists(x => x.Login == txtbx_login.Text &&
        x.Password == psswrd_password.Password)) main_window =
          new MainWindow();
      else MessageBox.Show("Login or password is incorrect!",
          "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }

    private void Register_Click(object sender, MouseButtonEventArgs e)
    {
      this.Close();
      register_window = new RegisterWindow();
    }
  }
}