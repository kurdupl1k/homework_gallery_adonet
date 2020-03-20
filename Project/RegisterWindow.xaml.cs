using System.Windows;
using System.Windows.Input;
using Project.Data.Models;
using Project.Data.Services;

namespace Project
{
  public partial class RegisterWindow : Window
  {
    private IService<User> userService;

    public RegisterWindow()
    {
      InitializeComponent();
      userService = new UserService();
    }

    private void Confirm_Click(object sender, RoutedEventArgs e)
    {
      string login, password;

      if (txtbx_login1.Text != txtbx_login2.Text)
      {
        MessageBox.Show("Logins are different!", "Error", MessageBoxButton.OK,
          MessageBoxImage.Error);
        return;
      }
      else
      {
        login = txtbx_login1.Text;
      }

      if (psswrdbx1.Password != psswrdbx2.Password)
      {
        MessageBox.Show("Passwords are different!", "Error",
          MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }
      else
      {
        password = psswrdbx1.Password;
      }

      userService.Add(new User()
      {
        Login = login,
        Password = password
      });

      if (MessageBox.Show("Account has been created!", "Success!",
        MessageBoxButton.OK, MessageBoxImage.Asterisk) == MessageBoxResult.OK)
      {
        Login_Click(null, null);
        Close();
      }
    }

    private void Login_Click(object sender, MouseButtonEventArgs e)
    {
      LoginWindow loginWindow = new LoginWindow();
      loginWindow.Show();

      Close();
    }
  }
}