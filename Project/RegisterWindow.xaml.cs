using System.Windows;
using System.Windows.Input;
using Project.Data.Models;
using Project.Data.Services;

namespace Project
{
  public partial class RegisterWindow : Window
  {
    private IService<User> user_service;

    public RegisterWindow()
    {
      InitializeComponent();
      user_service = new UserService();
    }

    private void Confirm_Click(object sender, RoutedEventArgs e)
    {
      string login;
      string password;

      if (txtbx_login1.Text != txtbx_login2.Text)
      {
        MessageBox.Show("logins are different!", "error", MessageBoxButton.OK,
          MessageBoxImage.Error);
        return;
      }
      else login = txtbx_login1.Text;

      if (psswrdbx1.Password != psswrdbx2.Password)
      {
        MessageBox.Show("passwords are different!", "error",
          MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }
      else password = psswrdbx1.Password;

      user_service.Add(new User() { Login = login, Password = password });
    }

    private void Login_Click(object sender, MouseButtonEventArgs e)
    {
      Close();

      LoginWindow login_window = new LoginWindow();
      login_window.Close();
    }
  }
}